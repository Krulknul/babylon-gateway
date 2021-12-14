/* Copyright 2021 Radix Publishing Ltd incorporated in Jersey (Channel Islands).
 *
 * Licensed under the Radix License, Version 1.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at:
 *
 * radixfoundation.org/licenses/LICENSE-v1
 *
 * The Licensor hereby grants permission for the Canonical version of the Work to be
 * published, distributed and used under or by reference to the Licensor’s trademark
 * Radix ® and use of any unregistered trade names, logos or get-up.
 *
 * The Licensor provides the Work (and each Contributor provides its Contributions) on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied,
 * including, without limitation, any warranties or conditions of TITLE, NON-INFRINGEMENT,
 * MERCHANTABILITY, or FITNESS FOR A PARTICULAR PURPOSE.
 *
 * Whilst the Work is capable of being deployed, used and adopted (instantiated) to create
 * a distributed ledger it is your responsibility to test and validate the code, together
 * with all logic and performance of that code under all foreseeable scenarios.
 *
 * The Licensor does not make or purport to make and hereby excludes liability for all
 * and any representation, warranty or undertaking in any form whatsoever, whether express
 * or implied, to any entity or person, including any representation, warranty or
 * undertaking, as to the functionality security use, value or other characteristics of
 * any distributed ledger nor in respect the functioning or value of any tokens which may
 * be created stored or transferred using the Work. The Licensor does not warrant that the
 * Work or any use of the Work complies with any law or regulation in any territory where
 * it may be implemented or used or that it will be appropriate for any specific purpose.
 *
 * Neither the licensor nor any current or former employees, officers, directors, partners,
 * trustees, representatives, agents, advisors, contractors, or volunteers of the Licensor
 * shall be liable for any direct or indirect, special, incidental, consequential or other
 * losses of any kind, in tort, contract or otherwise (including but not limited to loss
 * of revenue, income or profits, or loss of use or data, or loss of reputation, or loss
 * of any economic or other opportunity of whatsoever nature or howsoever arising), arising
 * out of or in connection with (without limitation of any use, misuse, of any ledger system
 * or use made or its functionality or any performance or operation of any code or protocol
 * caused by bugs or programming or logic errors or otherwise);
 *
 * A. any offer, purchase, holding, use, sale, exchange or transmission of any
 * cryptographic keys, tokens or assets created, exchanged, stored or arising from any
 * interaction with the Work;
 *
 * B. any failure in a transmission or loss of any token or assets keys or other digital
 * artefacts due to errors in transmission;
 *
 * C. bugs, hacks, logic errors or faults in the Work or any communication;
 *
 * D. system software or apparatus including but not limited to losses caused by errors
 * in holding or transmitting tokens by any third-party;
 *
 * E. breaches or failure of security including hacker attacks, loss or disclosure of
 * password, loss of private key, unauthorised use or misuse of such passwords or keys;
 *
 * F. any losses including loss of anticipated savings or other benefits resulting from
 * use of the Work or any changes to the Work (however implemented).
 *
 * You are solely responsible for; testing, validating and evaluation of all operation
 * logic, functionality, security and appropriateness of using the Work for any commercial
 * or non-commercial purpose and for any reproduction or redistribution by You of the
 * Work. You assume all risks associated with Your use of the Work and the exercise of
 * permissions under this License.
 */

using Common.CoreCommunications;
using Common.Database.Models.Mempool;
using Common.Exceptions;
using Common.Extensions;
using Common.Utilities;
using DataAggregator.Configuration;
using DataAggregator.Configuration.Models;
using DataAggregator.DependencyInjection;
using DataAggregator.NodeScopedServices;
using DataAggregator.NodeScopedServices.ApiReaders;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Prometheus;
using RadixCoreApi.Generated.Model;

namespace DataAggregator.GlobalServices;

public interface IMempoolResubmissionService
{
    Task RunBatchOfResubmissions(CancellationToken token = default);
}

public class MempoolResubmissionService : IMempoolResubmissionService
{
    private static readonly LogLimiter _emptyResubmissionQueueLogLimiter = new(TimeSpan.FromSeconds(60), LogLevel.Information, LogLevel.Debug);

    private static readonly Gauge _resubmissionQueueSize = Metrics
        .CreateGauge("mempool_transaction_resubmission_queue_length_count", "Number of transactions which have dropped out of mempools and need resubmitting.");

    private readonly IServiceProvider _services;
    private readonly IDbContextFactory<AggregatorDbContext> _dbContextFactory;
    private readonly IAggregatorConfiguration _aggregatorConfiguration;
    private readonly INetworkConfigurationProvider _networkConfigurationProvider;
    private readonly ILogger<MempoolResubmissionService> _logger;

    public MempoolResubmissionService(
        IServiceProvider services,
        IDbContextFactory<AggregatorDbContext> dbContextFactory,
        IAggregatorConfiguration aggregatorConfiguration,
        INetworkConfigurationProvider networkConfigurationProvider,
        ILogger<MempoolResubmissionService> logger
    )
    {
        _services = services;
        _dbContextFactory = dbContextFactory;
        _aggregatorConfiguration = aggregatorConfiguration;
        _networkConfigurationProvider = networkConfigurationProvider;
        _logger = logger;
    }

    public async Task RunBatchOfResubmissions(CancellationToken token = default)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(token);

        const int BatchSize = 30;

        var transactionsToResubmit =
            await GetMempoolTransactionsNeedingResubmission(dbContext)
                .OrderBy(mt => mt.LastSubmittedToNodeTimestamp)
                .Take(BatchSize)
                .ToListAsync(token);

        var totalTransactionsNeedingResubmission = transactionsToResubmit.Count < BatchSize
            ? transactionsToResubmit.Count
            : await GetMempoolTransactionsNeedingResubmission(dbContext).CountAsync(token);

        _resubmissionQueueSize.Set(0);

        if (totalTransactionsNeedingResubmission == 0)
        {
            _logger.Log(_emptyResubmissionQueueLogLimiter.GetLogLevel(), "There are no transactions needing resubmission");
        }
        else if (totalTransactionsNeedingResubmission <= BatchSize)
        {
            _logger.LogInformation("Preparing to resubmit {BatchSize} transactions", totalTransactionsNeedingResubmission);
        }
        else
        {
            _logger.LogWarning(
                "There are {TotalCount} transactions needing resubmission, but we are only resubmitting {BatchSize} this batch",
                totalTransactionsNeedingResubmission,
                transactionsToResubmit.Count
            );
        }

        var submittedAt = SystemClock.Instance.GetCurrentInstant();
        var submissionResults = await ResubmitAll(transactionsToResubmit, token);

        foreach (var (transaction, failed, failureReason, failureExplanation, nodeName) in submissionResults)
        {
            if (failed)
            {
                transaction.MarkAsInvalidOnceSubmittedToNode(nodeName, failureReason!.Value, failureExplanation!, submittedAt);
            }
            else
            {
                transaction.MarkAsSuccessfullySubmittedToNode(nodeName, submittedAt);
            }
        }

        await dbContext.SaveChangesAsync(token);
    }

    private IQueryable<MempoolTransaction> GetMempoolTransactionsNeedingResubmission(AggregatorDbContext dbContext)
    {
        var timeouts = _aggregatorConfiguration.GetMempoolConfiguration();

        var allowResubmissionIfLastSubmittedBefore = SystemClock.Instance.GetCurrentInstant() -
                                                     Duration.FromSeconds(timeouts.MinDelayBetweenResubmissionsSeconds);

        var allowResubmissionIfDroppedOutOfMempoolBefore = SystemClock.Instance.GetCurrentInstant() -
                                                     Duration.FromSeconds(timeouts.MinDelayBetweenMissingFromMempoolAndResubmissionSeconds);

        return dbContext.MempoolTransactions
            .Where(mt =>
                mt.SubmittedByThisGateway
                && mt.Status == MempoolTransactionStatus.Missing // This needs to be marked this way by the MempoolTrackerService
                && mt.LastDroppedOutOfMempoolTimestamp!.Value < allowResubmissionIfDroppedOutOfMempoolBefore
                && mt.LastSubmittedToNodeTimestamp!.Value < allowResubmissionIfLastSubmittedBefore
            );
    }

    private record SubmissionResult(
        MempoolTransaction MempoolTransaction,
        bool TransactionInvalid,
        MempoolTransactionFailureReason? FailureReason,
        string? SubmissionFailureExplanation,
        string NodeName
    );

    private async Task<SubmissionResult[]> ResubmitAll(List<MempoolTransaction> transactionsToResubmit, CancellationToken token)
    {
        return await Task.WhenAll(transactionsToResubmit.Select(t => Resubmit(t, token)));
    }

    private async Task<SubmissionResult> Resubmit(MempoolTransaction transaction, CancellationToken cancellationToken)
    {
        var chosenNode = GetRandomCoreApi();
        using var nodeScope = _services.CreateScope();
        nodeScope.ServiceProvider.GetRequiredService<INodeConfigProvider>().NodeAppSettings = chosenNode;
        var coreApiProvider = nodeScope.ServiceProvider.GetRequiredService<ICoreApiProvider>();

        var submitRequest = new ConstructionSubmitRequest(
            _networkConfigurationProvider.GetNetworkIdentifierForApiRequests(),
            transaction.Payload.ToHex()
        );

        try
        {
            await CoreApiErrorWrapper.ExtractCoreApiErrors(async () => await
                coreApiProvider.ConstructionApi.ConstructionSubmitPostAsync(submitRequest, cancellationToken)
            );
            return new SubmissionResult(transaction, false, null, null, chosenNode.Name);
        }
        catch (WrappedCoreApiException<SubstateDependencyNotFoundError> ex)
        {
            _logger.LogDebug(
                "Dropping transaction because of a double spend - possibly it's already been committed. Substate Identifier: {Substate}",
                ex.Error.SubstateIdentifierNotFound.Identifier
            );
            var failureExplanation = "Double spend on resubmission";
            return new SubmissionResult(transaction, true, MempoolTransactionFailureReason.DoubleSpend, failureExplanation, chosenNode.Name);
        }
        catch (WrappedCoreApiException ex) when (ex.Properties.Transience == Transience.Permanent)
        {
            var failureExplanation = $"Core API Exception: {ex.Error.GetType().Name} on resubmission";
            return new SubmissionResult(transaction, true, MempoolTransactionFailureReason.Unknown, failureExplanation, chosenNode.Name);
        }
        catch (Exception)
        {
            // Unsure of what the problem is -- it could be that the connection died or there was an internal server error
            // We have to assume the submission may have succeeded and wait for resubmission if not.
            return new SubmissionResult(transaction, false, null, null, chosenNode.Name);
        }
    }

    private NodeAppSettings GetRandomCoreApi()
    {
        return _aggregatorConfiguration.GetNodes()
            .Where(n => n.Enabled && !n.DisabledForConstruction)
            .GetRandomBy(_ => 1);
    }
}

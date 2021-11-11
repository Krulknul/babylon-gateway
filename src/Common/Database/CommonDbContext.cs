using Common.Database.Models;
using Common.Database.Models.Ledger;
using Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Common.Database;

/// <summary>
/// Common DB Context for the radixdlt-network-gateway database.
/// </summary>
public class CommonDbContext : DbContext
{
#pragma warning disable CS1591 // Remove need for public docs - instead refer to the Model docs

    public DbSet<Node> Nodes => Set<Node>();

    public DbSet<RawTransaction> RawTransactions => Set<RawTransaction>();

    public DbSet<LedgerTransaction> LedgerTransactions => Set<LedgerTransaction>();

#pragma warning restore CS1591

    public CommonDbContext(DbContextOptions<CommonDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LedgerTransaction>()
            .HasCheckConstraint(
                "CK_CompleteHistory",
                "state_version = 1 OR state_version = parent_state_version + 1"
            )
            .Property(lt => lt.FeePaid).AsTokenAmount();

        modelBuilder.Entity<LedgerTransaction>()
            .HasAlternateKey(lt => lt.TransactionIdentifierHash);

        modelBuilder.Entity<LedgerTransaction>()
            .HasAlternateKey(lt => lt.TransactionAccumulator);

        modelBuilder.Entity<LedgerTransaction>()
            .HasIndex(lt => new { lt.Epoch, lt.EndOfEpochRound })
            .IsUnique()
            .HasFilter("end_of_round IS NOT NULL");

        modelBuilder.Entity<OperationGroup>()
            .HasKey(og => new { og.ResultantStateVersion, og.OperationGroupIndex });

        modelBuilder.Entity<OperationGroup>()
            .OwnsOne(og => og.InferredAction, b => b
                .Property(ia => ia.Amount).AsTokenAmount()
            );
    }
}

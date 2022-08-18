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

/*
 * Radix Core API
 *
 * This API provides endpoints from a node for integration with the Radix ledger.  # Overview  > WARNING > > The Core API is __NOT__ intended to be available on the public web. It is > designed to be accessed in a private network.  The Core API is separated into three: * The **Data API** is a read-only api which allows you to view and sync to the state of the ledger. * The **Construction API** allows you to construct and submit a transaction to the network. * The **Key API** allows you to use the keys managed by the node to sign transactions.  The Core API is a low level API primarily designed for network integrations such as exchanges, ledger analytics providers, or hosted ledger data dashboards where detailed ledger data is required and the integrator can be expected to run their node to provide the Core API for their own consumption.  For a higher level API, see the [Gateway API](https://redocly.github.io/redoc/?url=https://raw.githubusercontent.com/radixdlt/radixdlt-network-gateway/main/generation/gateway-api-spec.yaml).  For node monitoring, see the [System API](https://redocly.github.io/redoc/?url=https://raw.githubusercontent.com/radixdlt/radixdlt/main/radixdlt-core/radixdlt/src/main/java/com/radixdlt/api/system/api.yaml).  ## Rosetta  The Data API and Construction API is inspired from [Rosetta API](https://www.rosetta-api.org/) most notably:   * Use of a JSON-Based RPC protocol on top of HTTP Post requests   * Use of Operations, Amounts, and Identifiers as universal language to   express asset movement for reading and writing  There are a few notable exceptions to note:   * Fetching of ledger data is through a Transaction stream rather than a   Block stream   * Use of `EntityIdentifier` rather than `AccountIdentifier`   * Use of `OperationGroup` rather than `related_operations` to express related   operations   * Construction endpoints perform coin selection on behalf of the caller.   This has the unfortunate effect of not being able to support high frequency   transactions from a single account. This will be addressed in future updates.   * Construction endpoints are online rather than offline as required by Rosetta  Future versions of the api will aim towards a fully-compliant Rosetta API.  ## Enabling Endpoints  All endpoints are enabled when running a node with the exception of two endpoints, each of which need to be manually configured to access: * `/transactions` endpoint must be enabled with configuration `api.transaction.enable=true`. This is because the transactions endpoint requires additional database storage which may not be needed for users who aren't using this endpoint * `/key/sign` endpoint must be enable with configuration `api.sign.enable=true`. This is a potentially dangerous endpoint if accessible publicly so it must be enabled manually.  ## Client Code Generation  We have found success with generating clients against the [api.yaml specification](https://raw.githubusercontent.com/radixdlt/radixdlt/main/radixdlt-core/radixdlt/src/main/java/com/radixdlt/api/core/api.yaml). See https://openapi-generator.tech/ for more details.  The OpenAPI generator only supports openapi version 3.0.0 at present, but you can change 3.1.0 to 3.0.0 in the first line of the spec without affecting generation.  # Data API Flow  The Data API can be used to synchronize a full or partial view of the ledger, transaction by transaction.  ![Data API Flow](https://raw.githubusercontent.com/radixdlt/radixdlt/feature/update-documentation/radixdlt-core/radixdlt/src/main/java/com/radixdlt/api/core/documentation/data_sequence_flow.png)  # Construction API Flow  The Construction API can be used to construct and submit transactions to the network.  ![Construction API Flow](https://raw.githubusercontent.com/radixdlt/radixdlt/feature/open-api/radixdlt-core/radixdlt/src/main/java/com/radixdlt/api/core/documentation/construction_sequence_flow.png)  Unlike the Rosetta Construction API [specification](https://www.rosetta-api.org/docs/construction_api_introduction.html), this Construction API selects UTXOs on behalf of the caller. This has the unfortunate side effect of not being able to support high frequency transactions from a single account due to UTXO conflicts. This will be addressed in a future release. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = RadixDlt.CoreApiSdk.Client.FileParameter;
using OpenAPIDateConverter = RadixDlt.CoreApiSdk.Client.OpenAPIDateConverter;

namespace RadixDlt.CoreApiSdk.Model
{
    /// <summary>
    /// TokenData
    /// </summary>
    [DataContract(Name = "TokenData")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(EpochData), "EpochData")]
    [JsonSubtypes.KnownSubType(typeof(PreparedValidatorFee), "PreparedValidatorFee")]
    [JsonSubtypes.KnownSubType(typeof(PreparedValidatorOwner), "PreparedValidatorOwner")]
    [JsonSubtypes.KnownSubType(typeof(PreparedValidatorRegistered), "PreparedValidatorRegistered")]
    [JsonSubtypes.KnownSubType(typeof(RoundData), "RoundData")]
    [JsonSubtypes.KnownSubType(typeof(TokenData), "TokenData")]
    [JsonSubtypes.KnownSubType(typeof(TokenMetadata), "TokenMetadata")]
    [JsonSubtypes.KnownSubType(typeof(UnclaimedRadixEngineAddress), "UnclaimedRadixEngineAddress")]
    [JsonSubtypes.KnownSubType(typeof(ValidatorAllowDelegation), "ValidatorAllowDelegation")]
    [JsonSubtypes.KnownSubType(typeof(ValidatorBFTData), "ValidatorBFTData")]
    [JsonSubtypes.KnownSubType(typeof(ValidatorData), "ValidatorData")]
    [JsonSubtypes.KnownSubType(typeof(ValidatorMetadata), "ValidatorMetadata")]
    [JsonSubtypes.KnownSubType(typeof(ValidatorSystemMetadata), "ValidatorSystemMetadata")]
    [JsonSubtypes.KnownSubType(typeof(VirtualParentData), "VirtualParentData")]
    public partial class TokenData : DataObject, IEquatable<TokenData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TokenData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenData" /> class.
        /// </summary>
        /// <param name="granularity">granularity (required).</param>
        /// <param name="isMutable">If true, the &#x60;owner&#x60; is able to mint/burn tokens. Otherwise, the token is a fixed supply token. (required).</param>
        /// <param name="owner">owner.</param>
        /// <param name="type">The type of the data object. Each address may own up to one current object of a given type. (required) (default to &quot;TokenData&quot;).</param>
        public TokenData(string granularity = default(string), bool isMutable = default(bool), EntityIdentifier owner = default(EntityIdentifier), string type = "TokenData") : base(type)
        {
            // to ensure "granularity" is required (not null)
            if (granularity == null)
            {
                throw new ArgumentNullException("granularity is a required property for TokenData and cannot be null");
            }
            this.Granularity = granularity;
            this.IsMutable = isMutable;
            this.Owner = owner;
        }

        /// <summary>
        /// Gets or Sets Granularity
        /// </summary>
        [DataMember(Name = "granularity", IsRequired = true, EmitDefaultValue = true)]
        public string Granularity { get; set; }

        /// <summary>
        /// If true, the &#x60;owner&#x60; is able to mint/burn tokens. Otherwise, the token is a fixed supply token.
        /// </summary>
        /// <value>If true, the &#x60;owner&#x60; is able to mint/burn tokens. Otherwise, the token is a fixed supply token.</value>
        [DataMember(Name = "is_mutable", IsRequired = true, EmitDefaultValue = true)]
        public bool IsMutable { get; set; }

        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        [DataMember(Name = "owner", EmitDefaultValue = true)]
        public EntityIdentifier Owner { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TokenData {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Granularity: ").Append(Granularity).Append("\n");
            sb.Append("  IsMutable: ").Append(IsMutable).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as TokenData);
        }

        /// <summary>
        /// Returns true if TokenData instances are equal
        /// </summary>
        /// <param name="input">Instance of TokenData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TokenData input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.Granularity == input.Granularity ||
                    (this.Granularity != null &&
                    this.Granularity.Equals(input.Granularity))
                ) && base.Equals(input) && 
                (
                    this.IsMutable == input.IsMutable ||
                    this.IsMutable.Equals(input.IsMutable)
                ) && base.Equals(input) && 
                (
                    this.Owner == input.Owner ||
                    (this.Owner != null &&
                    this.Owner.Equals(input.Owner))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.Granularity != null)
                {
                    hashCode = (hashCode * 59) + this.Granularity.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsMutable.GetHashCode();
                if (this.Owner != null)
                {
                    hashCode = (hashCode * 59) + this.Owner.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            // Granularity (string) pattern
            Regex regexGranularity = new Regex(@"^-?[0-9]+$", RegexOptions.CultureInvariant);
            if (false == regexGranularity.Match(this.Granularity).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Granularity, must match a pattern of " + regexGranularity, new [] { "Granularity" });
            }

            yield break;
        }
    }

}

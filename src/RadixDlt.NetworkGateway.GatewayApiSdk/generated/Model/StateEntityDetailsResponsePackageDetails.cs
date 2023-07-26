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
 * Babylon Gateway API - RCnet V2
 *
 * This API is exposed by the Babylon Radix Gateway to enable clients to efficiently query current and historic state on the RadixDLT ledger, and intelligently handle transaction submission.  It is designed for use by wallets and explorers. For simple use cases, you can typically use the Core API on a Node. A Gateway is only needed for reading historic snapshots of ledger states or a more robust set-up.  The Gateway API is implemented by the [Network Gateway](https://github.com/radixdlt/babylon-gateway), which is configured to read from [full node(s)](https://github.com/radixdlt/babylon-node) to extract and index data from the network.  This document is an API reference documentation, visit [User Guide](https://docs-babylon.radixdlt.com/) to learn more about how to run a Gateway of your own.  ## Migration guide  Please see [the latest release notes](https://github.com/radixdlt/babylon-gateway/releases).  ## Integration and forward compatibility guarantees  We give no guarantees that other endpoints will not change before Babylon mainnet launch, although changes are expected to be minimal. 
 *
 * The version of the OpenAPI document: 0.4.0
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
using FileParameter = RadixDlt.NetworkGateway.GatewayApiSdk.Client.FileParameter;
using OpenAPIDateConverter = RadixDlt.NetworkGateway.GatewayApiSdk.Client.OpenAPIDateConverter;

namespace RadixDlt.NetworkGateway.GatewayApiSdk.Model
{
    /// <summary>
    /// StateEntityDetailsResponsePackageDetails
    /// </summary>
    [DataContract(Name = "StateEntityDetailsResponsePackageDetails")]
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(StateEntityDetailsResponseComponentDetails), "Component")]
    [JsonSubtypes.KnownSubType(typeof(StateEntityDetailsResponseFungibleResourceDetails), "FungibleResource")]
    [JsonSubtypes.KnownSubType(typeof(StateEntityDetailsResponseFungibleVaultDetails), "FungibleVault")]
    [JsonSubtypes.KnownSubType(typeof(StateEntityDetailsResponseNonFungibleResourceDetails), "NonFungibleResource")]
    [JsonSubtypes.KnownSubType(typeof(StateEntityDetailsResponseNonFungibleVaultDetails), "NonFungibleVault")]
    [JsonSubtypes.KnownSubType(typeof(StateEntityDetailsResponsePackageDetails), "Package")]
    public partial class StateEntityDetailsResponsePackageDetails : StateEntityDetailsResponseItemDetails, IEquatable<StateEntityDetailsResponsePackageDetails>
    {

        /// <summary>
        /// Gets or Sets VmType
        /// </summary>
        [DataMember(Name = "vm_type", IsRequired = true, EmitDefaultValue = true)]
        public PackageVmType VmType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StateEntityDetailsResponsePackageDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected StateEntityDetailsResponsePackageDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="StateEntityDetailsResponsePackageDetails" /> class.
        /// </summary>
        /// <param name="vmType">vmType (required).</param>
        /// <param name="codeHashHex">Hex-encoded binary blob. (required).</param>
        /// <param name="codeHex">Hex-encoded binary blob..</param>
        /// <param name="schemaHashHex">Hex-encoded binary blob. (required).</param>
        /// <param name="schema">schema.</param>
        /// <param name="royaltyVaultBalance">String-encoded decimal representing the amount of a related fungible resource..</param>
        /// <param name="blueprints">blueprints.</param>
        /// <param name="type">type (required) (default to StateEntityDetailsResponseItemDetailsType.Package).</param>
        public StateEntityDetailsResponsePackageDetails(PackageVmType vmType = default(PackageVmType), string codeHashHex = default(string), string codeHex = default(string), string schemaHashHex = default(string), Object schema = default(Object), string royaltyVaultBalance = default(string), StateEntityDetailsResponsePackageDetailsBlueprintCollection blueprints = default(StateEntityDetailsResponsePackageDetailsBlueprintCollection), StateEntityDetailsResponseItemDetailsType type = StateEntityDetailsResponseItemDetailsType.Package) : base(type)
        {
            this.VmType = vmType;
            // to ensure "codeHashHex" is required (not null)
            if (codeHashHex == null)
            {
                throw new ArgumentNullException("codeHashHex is a required property for StateEntityDetailsResponsePackageDetails and cannot be null");
            }
            this.CodeHashHex = codeHashHex;
            // to ensure "schemaHashHex" is required (not null)
            if (schemaHashHex == null)
            {
                throw new ArgumentNullException("schemaHashHex is a required property for StateEntityDetailsResponsePackageDetails and cannot be null");
            }
            this.SchemaHashHex = schemaHashHex;
            this.CodeHex = codeHex;
            this.Schema = schema;
            this.RoyaltyVaultBalance = royaltyVaultBalance;
            this.Blueprints = blueprints;
        }

        /// <summary>
        /// Hex-encoded binary blob.
        /// </summary>
        /// <value>Hex-encoded binary blob.</value>
        [DataMember(Name = "code_hash_hex", IsRequired = true, EmitDefaultValue = true)]
        public string CodeHashHex { get; set; }

        /// <summary>
        /// Hex-encoded binary blob.
        /// </summary>
        /// <value>Hex-encoded binary blob.</value>
        [DataMember(Name = "code_hex", EmitDefaultValue = true)]
        public string CodeHex { get; set; }

        /// <summary>
        /// Hex-encoded binary blob.
        /// </summary>
        /// <value>Hex-encoded binary blob.</value>
        [DataMember(Name = "schema_hash_hex", IsRequired = true, EmitDefaultValue = true)]
        public string SchemaHashHex { get; set; }

        /// <summary>
        /// Gets or Sets Schema
        /// </summary>
        [DataMember(Name = "schema", EmitDefaultValue = true)]
        public Object Schema { get; set; }

        /// <summary>
        /// String-encoded decimal representing the amount of a related fungible resource.
        /// </summary>
        /// <value>String-encoded decimal representing the amount of a related fungible resource.</value>
        [DataMember(Name = "royalty_vault_balance", EmitDefaultValue = true)]
        public string RoyaltyVaultBalance { get; set; }

        /// <summary>
        /// Gets or Sets Blueprints
        /// </summary>
        [DataMember(Name = "blueprints", EmitDefaultValue = true)]
        public StateEntityDetailsResponsePackageDetailsBlueprintCollection Blueprints { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StateEntityDetailsResponsePackageDetails {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  VmType: ").Append(VmType).Append("\n");
            sb.Append("  CodeHashHex: ").Append(CodeHashHex).Append("\n");
            sb.Append("  CodeHex: ").Append(CodeHex).Append("\n");
            sb.Append("  SchemaHashHex: ").Append(SchemaHashHex).Append("\n");
            sb.Append("  Schema: ").Append(Schema).Append("\n");
            sb.Append("  RoyaltyVaultBalance: ").Append(RoyaltyVaultBalance).Append("\n");
            sb.Append("  Blueprints: ").Append(Blueprints).Append("\n");
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
            return this.Equals(input as StateEntityDetailsResponsePackageDetails);
        }

        /// <summary>
        /// Returns true if StateEntityDetailsResponsePackageDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of StateEntityDetailsResponsePackageDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StateEntityDetailsResponsePackageDetails input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.VmType == input.VmType ||
                    this.VmType.Equals(input.VmType)
                ) && base.Equals(input) && 
                (
                    this.CodeHashHex == input.CodeHashHex ||
                    (this.CodeHashHex != null &&
                    this.CodeHashHex.Equals(input.CodeHashHex))
                ) && base.Equals(input) && 
                (
                    this.CodeHex == input.CodeHex ||
                    (this.CodeHex != null &&
                    this.CodeHex.Equals(input.CodeHex))
                ) && base.Equals(input) && 
                (
                    this.SchemaHashHex == input.SchemaHashHex ||
                    (this.SchemaHashHex != null &&
                    this.SchemaHashHex.Equals(input.SchemaHashHex))
                ) && base.Equals(input) && 
                (
                    this.Schema == input.Schema ||
                    (this.Schema != null &&
                    this.Schema.Equals(input.Schema))
                ) && base.Equals(input) && 
                (
                    this.RoyaltyVaultBalance == input.RoyaltyVaultBalance ||
                    (this.RoyaltyVaultBalance != null &&
                    this.RoyaltyVaultBalance.Equals(input.RoyaltyVaultBalance))
                ) && base.Equals(input) && 
                (
                    this.Blueprints == input.Blueprints ||
                    (this.Blueprints != null &&
                    this.Blueprints.Equals(input.Blueprints))
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
                hashCode = (hashCode * 59) + this.VmType.GetHashCode();
                if (this.CodeHashHex != null)
                {
                    hashCode = (hashCode * 59) + this.CodeHashHex.GetHashCode();
                }
                if (this.CodeHex != null)
                {
                    hashCode = (hashCode * 59) + this.CodeHex.GetHashCode();
                }
                if (this.SchemaHashHex != null)
                {
                    hashCode = (hashCode * 59) + this.SchemaHashHex.GetHashCode();
                }
                if (this.Schema != null)
                {
                    hashCode = (hashCode * 59) + this.Schema.GetHashCode();
                }
                if (this.RoyaltyVaultBalance != null)
                {
                    hashCode = (hashCode * 59) + this.RoyaltyVaultBalance.GetHashCode();
                }
                if (this.Blueprints != null)
                {
                    hashCode = (hashCode * 59) + this.Blueprints.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}

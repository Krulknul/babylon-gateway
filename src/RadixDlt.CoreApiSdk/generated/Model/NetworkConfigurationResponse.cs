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
 * Babylon Core API - RCnet v3.1
 *
 * This API is exposed by the Babylon Radix node to give clients access to the Radix Engine, Mempool and State in the node.  It is intended for use by node-runners on a private network, and is not intended to be exposed publicly. Very heavy load may impact the node's function.  This API exposes queries against the node's current state (see `/lts/state/` or `/state/`), and streams of transaction history (under `/lts/stream/` or `/stream`).  If you require queries against snapshots of historical ledger state, you may also wish to consider using the [Gateway API](https://docs-babylon.radixdlt.com/).  ## Integration and forward compatibility guarantees  This version of the Core API belongs to the fourth release candidate of the Radix Babylon network (\"RCnet v3.1\").  Integrators (such as exchanges) are recommended to use the `/lts/` endpoints - they have been designed to be clear and simple for integrators wishing to create and monitor transactions involving fungible transfers to/from accounts.  All endpoints under `/lts/` are guaranteed to be forward compatible to Babylon mainnet launch (and beyond). We may add new fields, but existing fields will not be changed. Assuming the integrating code uses a permissive JSON parser which ignores unknown fields, any additions will not affect existing code. 
 *
 * The version of the OpenAPI document: 0.5.0
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
using FileParameter = RadixDlt.CoreApiSdk.Client.FileParameter;
using OpenAPIDateConverter = RadixDlt.CoreApiSdk.Client.OpenAPIDateConverter;

namespace RadixDlt.CoreApiSdk.Model
{
    /// <summary>
    /// NetworkConfigurationResponse
    /// </summary>
    [DataContract(Name = "NetworkConfigurationResponse")]
    public partial class NetworkConfigurationResponse : IEquatable<NetworkConfigurationResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkConfigurationResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NetworkConfigurationResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkConfigurationResponse" /> class.
        /// </summary>
        /// <param name="version">version (required).</param>
        /// <param name="network">The logical name of the network (required).</param>
        /// <param name="networkId">The logical id of the network (required).</param>
        /// <param name="networkHrpSuffix">The network suffix used for Bech32m HRPs used for addressing. (required).</param>
        /// <param name="usdPriceInXrd">The current value of the protocol-based USD/XRD multiplier (i.e. an amount of XRDs to be paid for 1 USD). A decimal is formed of some signed integer &#x60;m&#x60; of attos (&#x60;10^(-18)&#x60;) units, where &#x60;-2^(192 - 1) &lt;&#x3D; m &lt; 2^(192 - 1)&#x60;.  (required).</param>
        /// <param name="addressTypes">addressTypes (required).</param>
        /// <param name="wellKnownAddresses">wellKnownAddresses (required).</param>
        public NetworkConfigurationResponse(NetworkConfigurationResponseVersion version = default(NetworkConfigurationResponseVersion), string network = default(string), int networkId = default(int), string networkHrpSuffix = default(string), string usdPriceInXrd = default(string), List<AddressType> addressTypes = default(List<AddressType>), NetworkConfigurationResponseWellKnownAddresses wellKnownAddresses = default(NetworkConfigurationResponseWellKnownAddresses))
        {
            // to ensure "version" is required (not null)
            if (version == null)
            {
                throw new ArgumentNullException("version is a required property for NetworkConfigurationResponse and cannot be null");
            }
            this._Version = version;
            // to ensure "network" is required (not null)
            if (network == null)
            {
                throw new ArgumentNullException("network is a required property for NetworkConfigurationResponse and cannot be null");
            }
            this.Network = network;
            this.NetworkId = networkId;
            // to ensure "networkHrpSuffix" is required (not null)
            if (networkHrpSuffix == null)
            {
                throw new ArgumentNullException("networkHrpSuffix is a required property for NetworkConfigurationResponse and cannot be null");
            }
            this.NetworkHrpSuffix = networkHrpSuffix;
            // to ensure "usdPriceInXrd" is required (not null)
            if (usdPriceInXrd == null)
            {
                throw new ArgumentNullException("usdPriceInXrd is a required property for NetworkConfigurationResponse and cannot be null");
            }
            this.UsdPriceInXrd = usdPriceInXrd;
            // to ensure "addressTypes" is required (not null)
            if (addressTypes == null)
            {
                throw new ArgumentNullException("addressTypes is a required property for NetworkConfigurationResponse and cannot be null");
            }
            this.AddressTypes = addressTypes;
            // to ensure "wellKnownAddresses" is required (not null)
            if (wellKnownAddresses == null)
            {
                throw new ArgumentNullException("wellKnownAddresses is a required property for NetworkConfigurationResponse and cannot be null");
            }
            this.WellKnownAddresses = wellKnownAddresses;
        }

        /// <summary>
        /// Gets or Sets _Version
        /// </summary>
        [DataMember(Name = "version", IsRequired = true, EmitDefaultValue = true)]
        public NetworkConfigurationResponseVersion _Version { get; set; }

        /// <summary>
        /// The logical name of the network
        /// </summary>
        /// <value>The logical name of the network</value>
        [DataMember(Name = "network", IsRequired = true, EmitDefaultValue = true)]
        public string Network { get; set; }

        /// <summary>
        /// The logical id of the network
        /// </summary>
        /// <value>The logical id of the network</value>
        [DataMember(Name = "network_id", IsRequired = true, EmitDefaultValue = true)]
        public int NetworkId { get; set; }

        /// <summary>
        /// The network suffix used for Bech32m HRPs used for addressing.
        /// </summary>
        /// <value>The network suffix used for Bech32m HRPs used for addressing.</value>
        [DataMember(Name = "network_hrp_suffix", IsRequired = true, EmitDefaultValue = true)]
        public string NetworkHrpSuffix { get; set; }

        /// <summary>
        /// The current value of the protocol-based USD/XRD multiplier (i.e. an amount of XRDs to be paid for 1 USD). A decimal is formed of some signed integer &#x60;m&#x60; of attos (&#x60;10^(-18)&#x60;) units, where &#x60;-2^(192 - 1) &lt;&#x3D; m &lt; 2^(192 - 1)&#x60;. 
        /// </summary>
        /// <value>The current value of the protocol-based USD/XRD multiplier (i.e. an amount of XRDs to be paid for 1 USD). A decimal is formed of some signed integer &#x60;m&#x60; of attos (&#x60;10^(-18)&#x60;) units, where &#x60;-2^(192 - 1) &lt;&#x3D; m &lt; 2^(192 - 1)&#x60;. </value>
        [DataMember(Name = "usd_price_in_xrd", IsRequired = true, EmitDefaultValue = true)]
        public string UsdPriceInXrd { get; set; }

        /// <summary>
        /// Gets or Sets AddressTypes
        /// </summary>
        [DataMember(Name = "address_types", IsRequired = true, EmitDefaultValue = true)]
        public List<AddressType> AddressTypes { get; set; }

        /// <summary>
        /// Gets or Sets WellKnownAddresses
        /// </summary>
        [DataMember(Name = "well_known_addresses", IsRequired = true, EmitDefaultValue = true)]
        public NetworkConfigurationResponseWellKnownAddresses WellKnownAddresses { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NetworkConfigurationResponse {\n");
            sb.Append("  _Version: ").Append(_Version).Append("\n");
            sb.Append("  Network: ").Append(Network).Append("\n");
            sb.Append("  NetworkId: ").Append(NetworkId).Append("\n");
            sb.Append("  NetworkHrpSuffix: ").Append(NetworkHrpSuffix).Append("\n");
            sb.Append("  UsdPriceInXrd: ").Append(UsdPriceInXrd).Append("\n");
            sb.Append("  AddressTypes: ").Append(AddressTypes).Append("\n");
            sb.Append("  WellKnownAddresses: ").Append(WellKnownAddresses).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
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
            return this.Equals(input as NetworkConfigurationResponse);
        }

        /// <summary>
        /// Returns true if NetworkConfigurationResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of NetworkConfigurationResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NetworkConfigurationResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this._Version == input._Version ||
                    (this._Version != null &&
                    this._Version.Equals(input._Version))
                ) && 
                (
                    this.Network == input.Network ||
                    (this.Network != null &&
                    this.Network.Equals(input.Network))
                ) && 
                (
                    this.NetworkId == input.NetworkId ||
                    this.NetworkId.Equals(input.NetworkId)
                ) && 
                (
                    this.NetworkHrpSuffix == input.NetworkHrpSuffix ||
                    (this.NetworkHrpSuffix != null &&
                    this.NetworkHrpSuffix.Equals(input.NetworkHrpSuffix))
                ) && 
                (
                    this.UsdPriceInXrd == input.UsdPriceInXrd ||
                    (this.UsdPriceInXrd != null &&
                    this.UsdPriceInXrd.Equals(input.UsdPriceInXrd))
                ) && 
                (
                    this.AddressTypes == input.AddressTypes ||
                    this.AddressTypes != null &&
                    input.AddressTypes != null &&
                    this.AddressTypes.SequenceEqual(input.AddressTypes)
                ) && 
                (
                    this.WellKnownAddresses == input.WellKnownAddresses ||
                    (this.WellKnownAddresses != null &&
                    this.WellKnownAddresses.Equals(input.WellKnownAddresses))
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
                int hashCode = 41;
                if (this._Version != null)
                {
                    hashCode = (hashCode * 59) + this._Version.GetHashCode();
                }
                if (this.Network != null)
                {
                    hashCode = (hashCode * 59) + this.Network.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.NetworkId.GetHashCode();
                if (this.NetworkHrpSuffix != null)
                {
                    hashCode = (hashCode * 59) + this.NetworkHrpSuffix.GetHashCode();
                }
                if (this.UsdPriceInXrd != null)
                {
                    hashCode = (hashCode * 59) + this.UsdPriceInXrd.GetHashCode();
                }
                if (this.AddressTypes != null)
                {
                    hashCode = (hashCode * 59) + this.AddressTypes.GetHashCode();
                }
                if (this.WellKnownAddresses != null)
                {
                    hashCode = (hashCode * 59) + this.WellKnownAddresses.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}

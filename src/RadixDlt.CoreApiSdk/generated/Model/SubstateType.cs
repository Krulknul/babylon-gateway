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
 * Babylon Core API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.0
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
using System.ComponentModel.DataAnnotations;
using FileParameter = RadixDlt.CoreApiSdk.Client.FileParameter;
using OpenAPIDateConverter = RadixDlt.CoreApiSdk.Client.OpenAPIDateConverter;

namespace RadixDlt.CoreApiSdk.Model
{
    /// <summary>
    /// Defines SubstateType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubstateType
    {
        /// <summary>
        /// Enum Metadata for value: Metadata
        /// </summary>
        [EnumMember(Value = "Metadata")]
        Metadata = 1,

        /// <summary>
        /// Enum AccessRulesChain for value: AccessRulesChain
        /// </summary>
        [EnumMember(Value = "AccessRulesChain")]
        AccessRulesChain = 2,

        /// <summary>
        /// Enum GlobalAddress for value: GlobalAddress
        /// </summary>
        [EnumMember(Value = "GlobalAddress")]
        GlobalAddress = 3,

        /// <summary>
        /// Enum ComponentInfo for value: ComponentInfo
        /// </summary>
        [EnumMember(Value = "ComponentInfo")]
        ComponentInfo = 4,

        /// <summary>
        /// Enum ComponentState for value: ComponentState
        /// </summary>
        [EnumMember(Value = "ComponentState")]
        ComponentState = 5,

        /// <summary>
        /// Enum ComponentRoyaltyConfig for value: ComponentRoyaltyConfig
        /// </summary>
        [EnumMember(Value = "ComponentRoyaltyConfig")]
        ComponentRoyaltyConfig = 6,

        /// <summary>
        /// Enum ComponentRoyaltyAccumulator for value: ComponentRoyaltyAccumulator
        /// </summary>
        [EnumMember(Value = "ComponentRoyaltyAccumulator")]
        ComponentRoyaltyAccumulator = 7,

        /// <summary>
        /// Enum PackageInfo for value: PackageInfo
        /// </summary>
        [EnumMember(Value = "PackageInfo")]
        PackageInfo = 8,

        /// <summary>
        /// Enum PackageRoyaltyConfig for value: PackageRoyaltyConfig
        /// </summary>
        [EnumMember(Value = "PackageRoyaltyConfig")]
        PackageRoyaltyConfig = 9,

        /// <summary>
        /// Enum PackageRoyaltyAccumulator for value: PackageRoyaltyAccumulator
        /// </summary>
        [EnumMember(Value = "PackageRoyaltyAccumulator")]
        PackageRoyaltyAccumulator = 10,

        /// <summary>
        /// Enum ResourceManager for value: ResourceManager
        /// </summary>
        [EnumMember(Value = "ResourceManager")]
        ResourceManager = 11,

        /// <summary>
        /// Enum EpochManager for value: EpochManager
        /// </summary>
        [EnumMember(Value = "EpochManager")]
        EpochManager = 12,

        /// <summary>
        /// Enum ClockCurrentMinute for value: ClockCurrentMinute
        /// </summary>
        [EnumMember(Value = "ClockCurrentMinute")]
        ClockCurrentMinute = 13,

        /// <summary>
        /// Enum KeyValueStoreEntry for value: KeyValueStoreEntry
        /// </summary>
        [EnumMember(Value = "KeyValueStoreEntry")]
        KeyValueStoreEntry = 14,

        /// <summary>
        /// Enum NonFungibleStoreEntry for value: NonFungibleStoreEntry
        /// </summary>
        [EnumMember(Value = "NonFungibleStoreEntry")]
        NonFungibleStoreEntry = 15,

        /// <summary>
        /// Enum Vault for value: Vault
        /// </summary>
        [EnumMember(Value = "Vault")]
        Vault = 16

    }

}

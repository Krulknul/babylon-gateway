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
 * Radix Babylon Gateway API
 *
 * See https://docs.radixdlt.com/main/apis/introduction.html 
 *
 * The version of the OpenAPI document: 2.0.0
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
using FileParameter = RadixDlt.NetworkGateway.GatewayApiSdk.Client.FileParameter;
using OpenAPIDateConverter = RadixDlt.NetworkGateway.GatewayApiSdk.Client.OpenAPIDateConverter;

namespace RadixDlt.NetworkGateway.GatewayApiSdk.Model
{
    /// <summary>
    /// InvalidPublicKeyError
    /// </summary>
    [DataContract(Name = "InvalidPublicKeyError")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(BelowMinimumStakeError), "BelowMinimumStakeError")]
    [JsonSubtypes.KnownSubType(typeof(CannotStakeError), "CannotStakeError")]
    [JsonSubtypes.KnownSubType(typeof(CouldNotConstructFeesError), "CouldNotConstructFeesError")]
    [JsonSubtypes.KnownSubType(typeof(InternalServerError), "InternalServerError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidAccountAddressError), "InvalidAccountAddressError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidActionError), "InvalidActionError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidPublicKeyError), "InvalidPublicKeyError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidRequestError), "InvalidRequestError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidSignatureError), "InvalidSignatureError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidTokenRRIError), "InvalidTokenRRIError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidTokenSymbolError), "InvalidTokenSymbolError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidTransactionError), "InvalidTransactionError")]
    [JsonSubtypes.KnownSubType(typeof(InvalidValidatorAddressError), "InvalidValidatorAddressError")]
    [JsonSubtypes.KnownSubType(typeof(MessageTooLongError), "MessageTooLongError")]
    [JsonSubtypes.KnownSubType(typeof(NotEnoughNativeTokensForFeesError), "NotEnoughNativeTokensForFeesError")]
    [JsonSubtypes.KnownSubType(typeof(NotEnoughTokensForStakeError), "NotEnoughTokensForStakeError")]
    [JsonSubtypes.KnownSubType(typeof(NotEnoughTokensForTransferError), "NotEnoughTokensForTransferError")]
    [JsonSubtypes.KnownSubType(typeof(NotEnoughTokensForUnstakeError), "NotEnoughTokensForUnstakeError")]
    [JsonSubtypes.KnownSubType(typeof(NotSyncedUpError), "NotSyncedUpError")]
    [JsonSubtypes.KnownSubType(typeof(TokenNotFoundError), "TokenNotFoundError")]
    [JsonSubtypes.KnownSubType(typeof(TransactionNotFoundError), "TransactionNotFoundError")]
    public partial class InvalidPublicKeyError : GatewayError, IEquatable<InvalidPublicKeyError>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPublicKeyError" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InvalidPublicKeyError() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPublicKeyError" /> class.
        /// </summary>
        /// <param name="invalidPublicKey">The public key which was invalid. A descriptive reason is given in the main error message. (required).</param>
        /// <param name="type">The type of error. Each subtype may have its own additional structured fields. (required) (default to &quot;InvalidPublicKeyError&quot;).</param>
        public InvalidPublicKeyError(string invalidPublicKey = default(string), string type = "InvalidPublicKeyError") : base(type)
        {
            // to ensure "invalidPublicKey" is required (not null)
            if (invalidPublicKey == null)
            {
                throw new ArgumentNullException("invalidPublicKey is a required property for InvalidPublicKeyError and cannot be null");
            }
            this.InvalidPublicKey = invalidPublicKey;
        }

        /// <summary>
        /// The public key which was invalid. A descriptive reason is given in the main error message.
        /// </summary>
        /// <value>The public key which was invalid. A descriptive reason is given in the main error message.</value>
        [DataMember(Name = "invalid_public_key", IsRequired = true, EmitDefaultValue = true)]
        public string InvalidPublicKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InvalidPublicKeyError {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  InvalidPublicKey: ").Append(InvalidPublicKey).Append("\n");
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
            return this.Equals(input as InvalidPublicKeyError);
        }

        /// <summary>
        /// Returns true if InvalidPublicKeyError instances are equal
        /// </summary>
        /// <param name="input">Instance of InvalidPublicKeyError to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InvalidPublicKeyError input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.InvalidPublicKey == input.InvalidPublicKey ||
                    (this.InvalidPublicKey != null &&
                    this.InvalidPublicKey.Equals(input.InvalidPublicKey))
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
                if (this.InvalidPublicKey != null)
                {
                    hashCode = (hashCode * 59) + this.InvalidPublicKey.GetHashCode();
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
            yield break;
        }
    }

}

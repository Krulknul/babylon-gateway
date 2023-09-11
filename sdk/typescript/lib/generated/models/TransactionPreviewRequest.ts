/* tslint:disable */
/* eslint-disable */
/**
 * Babylon Gateway API - RCnet V3
 * This API is exposed by the Babylon Radix Gateway to enable clients to efficiently query current and historic state on the RadixDLT ledger, and intelligently handle transaction submission.  It is designed for use by wallets and explorers. For simple use cases, you can typically use the Core API on a Node. A Gateway is only needed for reading historic snapshots of ledger states or a more robust set-up.  The Gateway API is implemented by the [Network Gateway](https://github.com/radixdlt/babylon-gateway), which is configured to read from [full node(s)](https://github.com/radixdlt/babylon-node) to extract and index data from the network.  This document is an API reference documentation, visit [User Guide](https://docs-babylon.radixdlt.com/) to learn more about how to run a Gateway of your own.  ## Migration guide  Please see [the latest release notes](https://github.com/radixdlt/babylon-gateway/releases).  ## Integration and forward compatibility guarantees  We give no guarantees that other endpoints will not change before Babylon mainnet launch, although changes are expected to be minimal. 
 *
 * The version of the OpenAPI document: 0.5.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
import type { PublicKey } from './PublicKey';
import {
    PublicKeyFromJSON,
    PublicKeyFromJSONTyped,
    PublicKeyToJSON,
} from './PublicKey';
import type { TransactionPreviewRequestFlags } from './TransactionPreviewRequestFlags';
import {
    TransactionPreviewRequestFlagsFromJSON,
    TransactionPreviewRequestFlagsFromJSONTyped,
    TransactionPreviewRequestFlagsToJSON,
} from './TransactionPreviewRequestFlags';

/**
 * 
 * @export
 * @interface TransactionPreviewRequest
 */
export interface TransactionPreviewRequest {
    /**
     * A text-representation of a transaction manifest
     * @type {string}
     * @memberof TransactionPreviewRequest
     */
    manifest: string;
    /**
     * An array of hex-encoded blob data (optional)
     * @type {Array<string>}
     * @memberof TransactionPreviewRequest
     */
    blobs_hex?: Array<string>;
    /**
     * An integer between `0` and `10^10`, marking the epoch at which the transaction starts being valid
     * @type {number}
     * @memberof TransactionPreviewRequest
     */
    start_epoch_inclusive: number;
    /**
     * An integer between `0` and `10^10`, marking the epoch at which the transaction is no longer valid
     * @type {number}
     * @memberof TransactionPreviewRequest
     */
    end_epoch_exclusive: number;
    /**
     * 
     * @type {PublicKey}
     * @memberof TransactionPreviewRequest
     */
    notary_public_key?: PublicKey;
    /**
     * Whether the notary should count as a signatory (optional, default false)
     * @type {boolean}
     * @memberof TransactionPreviewRequest
     */
    notary_is_signatory?: boolean;
    /**
     * An integer between `0` and `255`, giving the validator tip as a percentage amount. A value of `1` corresponds to 1% of the fee.
     * @type {number}
     * @memberof TransactionPreviewRequest
     */
    tip_percentage: number;
    /**
     * A decimal-string-encoded integer between `0` and `2^32 - 1`, used to ensure the transaction intent is unique.
     * @type {number}
     * @memberof TransactionPreviewRequest
     */
    nonce: number;
    /**
     * A list of public keys to be used as transaction signers
     * @type {Array<PublicKey>}
     * @memberof TransactionPreviewRequest
     */
    signer_public_keys: Array<PublicKey>;
    /**
     * 
     * @type {TransactionPreviewRequestFlags}
     * @memberof TransactionPreviewRequest
     */
    flags: TransactionPreviewRequestFlags;
}

/**
 * Check if a given object implements the TransactionPreviewRequest interface.
 */
export function instanceOfTransactionPreviewRequest(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "manifest" in value;
    isInstance = isInstance && "start_epoch_inclusive" in value;
    isInstance = isInstance && "end_epoch_exclusive" in value;
    isInstance = isInstance && "tip_percentage" in value;
    isInstance = isInstance && "nonce" in value;
    isInstance = isInstance && "signer_public_keys" in value;
    isInstance = isInstance && "flags" in value;

    return isInstance;
}

export function TransactionPreviewRequestFromJSON(json: any): TransactionPreviewRequest {
    return TransactionPreviewRequestFromJSONTyped(json, false);
}

export function TransactionPreviewRequestFromJSONTyped(json: any, ignoreDiscriminator: boolean): TransactionPreviewRequest {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'manifest': json['manifest'],
        'blobs_hex': !exists(json, 'blobs_hex') ? undefined : json['blobs_hex'],
        'start_epoch_inclusive': json['start_epoch_inclusive'],
        'end_epoch_exclusive': json['end_epoch_exclusive'],
        'notary_public_key': !exists(json, 'notary_public_key') ? undefined : PublicKeyFromJSON(json['notary_public_key']),
        'notary_is_signatory': !exists(json, 'notary_is_signatory') ? undefined : json['notary_is_signatory'],
        'tip_percentage': json['tip_percentage'],
        'nonce': json['nonce'],
        'signer_public_keys': ((json['signer_public_keys'] as Array<any>).map(PublicKeyFromJSON)),
        'flags': TransactionPreviewRequestFlagsFromJSON(json['flags']),
    };
}

export function TransactionPreviewRequestToJSON(value?: TransactionPreviewRequest | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'manifest': value.manifest,
        'blobs_hex': value.blobs_hex,
        'start_epoch_inclusive': value.start_epoch_inclusive,
        'end_epoch_exclusive': value.end_epoch_exclusive,
        'notary_public_key': PublicKeyToJSON(value.notary_public_key),
        'notary_is_signatory': value.notary_is_signatory,
        'tip_percentage': value.tip_percentage,
        'nonce': value.nonce,
        'signer_public_keys': ((value.signer_public_keys as Array<any>).map(PublicKeyToJSON)),
        'flags': TransactionPreviewRequestFlagsToJSON(value.flags),
    };
}


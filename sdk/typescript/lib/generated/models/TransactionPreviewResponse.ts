/* tslint:disable */
/* eslint-disable */
/**
 * Babylon Gateway API - RCnet V1
 * This API is exposed by the Babylon Radix Gateway to enable clients to efficiently query current and historic state on the RadixDLT ledger, and intelligently handle transaction submission.  It is designed for use by wallets and explorers. For simple use cases, you can typically use the Core API on a Node. A Gateway is only needed for reading historic snapshots of ledger states or a more robust set-up.  The Gateway API is implemented by the [Network Gateway](https://github.com/radixdlt/babylon-gateway), which is configured to read from [full node(s)](https://github.com/radixdlt/babylon-node) to extract and index data from the network.  This document is an API reference documentation, visit [User Guide](https://docs-babylon.radixdlt.com/) to learn more about how to run a Gateway of your own.  ## Integration and forward compatibility guarantees  We give no guarantees that other endpoints will not change before Babylon mainnet launch, although changes are expected to be minimal. 
 *
 * The version of the OpenAPI document: 0.3.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
import type { TransactionPreviewResponseLogsInner } from './TransactionPreviewResponseLogsInner';
import {
    TransactionPreviewResponseLogsInnerFromJSON,
    TransactionPreviewResponseLogsInnerFromJSONTyped,
    TransactionPreviewResponseLogsInnerToJSON,
} from './TransactionPreviewResponseLogsInner';

/**
 * 
 * @export
 * @interface TransactionPreviewResponse
 */
export interface TransactionPreviewResponse {
    /**
     * Hex-encoded binary blob.
     * @type {string}
     * @memberof TransactionPreviewResponse
     */
    encoded_receipt: string;
    /**
     * 
     * @type {object}
     * @memberof TransactionPreviewResponse
     */
    receipt: object;
    /**
     * 
     * @type {Array<object>}
     * @memberof TransactionPreviewResponse
     */
    resource_changes: Array<object>;
    /**
     * 
     * @type {Array<TransactionPreviewResponseLogsInner>}
     * @memberof TransactionPreviewResponse
     */
    logs: Array<TransactionPreviewResponseLogsInner>;
}

/**
 * Check if a given object implements the TransactionPreviewResponse interface.
 */
export function instanceOfTransactionPreviewResponse(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "encoded_receipt" in value;
    isInstance = isInstance && "receipt" in value;
    isInstance = isInstance && "resource_changes" in value;
    isInstance = isInstance && "logs" in value;

    return isInstance;
}

export function TransactionPreviewResponseFromJSON(json: any): TransactionPreviewResponse {
    return TransactionPreviewResponseFromJSONTyped(json, false);
}

export function TransactionPreviewResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): TransactionPreviewResponse {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'encoded_receipt': json['encoded_receipt'],
        'receipt': json['receipt'],
        'resource_changes': json['resource_changes'],
        'logs': ((json['logs'] as Array<any>).map(TransactionPreviewResponseLogsInnerFromJSON)),
    };
}

export function TransactionPreviewResponseToJSON(value?: TransactionPreviewResponse | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'encoded_receipt': value.encoded_receipt,
        'receipt': value.receipt,
        'resource_changes': value.resource_changes,
        'logs': ((value.logs as Array<any>).map(TransactionPreviewResponseLogsInnerToJSON)),
    };
}


/* tslint:disable */
/* eslint-disable */
/**
 * Babylon Gateway API - RCnet V2
 * This API is exposed by the Babylon Radix Gateway to enable clients to efficiently query current and historic state on the RadixDLT ledger, and intelligently handle transaction submission.  It is designed for use by wallets and explorers. For simple use cases, you can typically use the Core API on a Node. A Gateway is only needed for reading historic snapshots of ledger states or a more robust set-up.  The Gateway API is implemented by the [Network Gateway](https://github.com/radixdlt/babylon-gateway), which is configured to read from [full node(s)](https://github.com/radixdlt/babylon-node) to extract and index data from the network.  This document is an API reference documentation, visit [User Guide](https://docs-babylon.radixdlt.com/) to learn more about how to run a Gateway of your own.  ## Migration guide  Please see [the latest release notes](https://github.com/radixdlt/babylon-gateway/releases).  ## Integration and forward compatibility guarantees  We give no guarantees that other endpoints will not change before Babylon mainnet launch, although changes are expected to be minimal. 
 *
 * The version of the OpenAPI document: 0.4.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface StreamTransactionsRequestEventFilterItem
 */
export interface StreamTransactionsRequestEventFilterItem {
    /**
     * 
     * @type {string}
     * @memberof StreamTransactionsRequestEventFilterItem
     */
    event: StreamTransactionsRequestEventFilterItemEventEnum;
    /**
     * Bech32m-encoded human readable version of the address.
     * @type {string}
     * @memberof StreamTransactionsRequestEventFilterItem
     */
    emitter_address?: string;
    /**
     * Bech32m-encoded human readable version of the address.
     * @type {string}
     * @memberof StreamTransactionsRequestEventFilterItem
     */
    resource_address?: string;
    /**
     * String-encoded decimal representing the amount of a related fungible resource.
     * @type {string}
     * @memberof StreamTransactionsRequestEventFilterItem
     */
    quantity?: string;
}


/**
 * @export
 */
export const StreamTransactionsRequestEventFilterItemEventEnum = {
    Deposit: 'Deposit',
    Withdrawal: 'Withdrawal'
} as const;
export type StreamTransactionsRequestEventFilterItemEventEnum = typeof StreamTransactionsRequestEventFilterItemEventEnum[keyof typeof StreamTransactionsRequestEventFilterItemEventEnum];


/**
 * Check if a given object implements the StreamTransactionsRequestEventFilterItem interface.
 */
export function instanceOfStreamTransactionsRequestEventFilterItem(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "event" in value;

    return isInstance;
}

export function StreamTransactionsRequestEventFilterItemFromJSON(json: any): StreamTransactionsRequestEventFilterItem {
    return StreamTransactionsRequestEventFilterItemFromJSONTyped(json, false);
}

export function StreamTransactionsRequestEventFilterItemFromJSONTyped(json: any, ignoreDiscriminator: boolean): StreamTransactionsRequestEventFilterItem {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'event': json['event'],
        'emitter_address': !exists(json, 'emitter_address') ? undefined : json['emitter_address'],
        'resource_address': !exists(json, 'resource_address') ? undefined : json['resource_address'],
        'quantity': !exists(json, 'quantity') ? undefined : json['quantity'],
    };
}

export function StreamTransactionsRequestEventFilterItemToJSON(value?: StreamTransactionsRequestEventFilterItem | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'event': value.event,
        'emitter_address': value.emitter_address,
        'resource_address': value.resource_address,
        'quantity': value.quantity,
    };
}


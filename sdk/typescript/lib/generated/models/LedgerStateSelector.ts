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
/**
 * Optional. This allows for a request to be made against a historic state.
 * If a constraint is specified, the Gateway will resolve the request against the ledger state at that time.
 * If not specified, requests will be made with respect to the top of the committed ledger.
 * @export
 * @interface LedgerStateSelector
 */
export interface LedgerStateSelector {
    /**
     * If provided, the latest ledger state lower than or equal to the given state version is returned.
     * @type {number}
     * @memberof LedgerStateSelector
     */
    state_version?: number | null;
    /**
     * If provided, the latest ledger state lower than or equal to the given round timestamp is returned.
     * @type {Date}
     * @memberof LedgerStateSelector
     */
    timestamp?: Date | null;
    /**
     * If provided, the ledger state lower than or equal to the given epoch at round 0 is returned.
     * @type {number}
     * @memberof LedgerStateSelector
     */
    epoch?: number | null;
    /**
     * If provided must be accompanied with `epoch`, the ledger state lower than or equal to the given epoch and round is returned.
     * @type {number}
     * @memberof LedgerStateSelector
     */
    round?: number | null;
}

/**
 * Check if a given object implements the LedgerStateSelector interface.
 */
export function instanceOfLedgerStateSelector(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function LedgerStateSelectorFromJSON(json: any): LedgerStateSelector {
    return LedgerStateSelectorFromJSONTyped(json, false);
}

export function LedgerStateSelectorFromJSONTyped(json: any, ignoreDiscriminator: boolean): LedgerStateSelector {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'state_version': !exists(json, 'state_version') ? undefined : json['state_version'],
        'timestamp': !exists(json, 'timestamp') ? undefined : (json['timestamp'] === null ? null : new Date(json['timestamp'])),
        'epoch': !exists(json, 'epoch') ? undefined : json['epoch'],
        'round': !exists(json, 'round') ? undefined : json['round'],
    };
}

export function LedgerStateSelectorToJSON(value?: LedgerStateSelector | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'state_version': value.state_version,
        'timestamp': value.timestamp === undefined ? undefined : (value.timestamp === null ? null : value.timestamp.toISOString()),
        'epoch': value.epoch,
        'round': value.round,
    };
}


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
import type { LedgerStateSelector } from './LedgerStateSelector';
import {
    LedgerStateSelectorFromJSON,
    LedgerStateSelectorFromJSONTyped,
    LedgerStateSelectorToJSON,
} from './LedgerStateSelector';
import type { ResourceAggregationLevel } from './ResourceAggregationLevel';
import {
    ResourceAggregationLevelFromJSON,
    ResourceAggregationLevelFromJSONTyped,
    ResourceAggregationLevelToJSON,
} from './ResourceAggregationLevel';
import type { StateEntityNonFungiblesPageRequestOptIns } from './StateEntityNonFungiblesPageRequestOptIns';
import {
    StateEntityNonFungiblesPageRequestOptInsFromJSON,
    StateEntityNonFungiblesPageRequestOptInsFromJSONTyped,
    StateEntityNonFungiblesPageRequestOptInsToJSON,
} from './StateEntityNonFungiblesPageRequestOptIns';

/**
 * 
 * @export
 * @interface StateEntityNonFungiblesPageRequest
 */
export interface StateEntityNonFungiblesPageRequest {
    /**
     * 
     * @type {LedgerStateSelector}
     * @memberof StateEntityNonFungiblesPageRequest
     */
    at_ledger_state?: LedgerStateSelector | null;
    /**
     * This cursor allows forward pagination, by providing the cursor from the previous request.
     * @type {string}
     * @memberof StateEntityNonFungiblesPageRequest
     */
    cursor?: string | null;
    /**
     * The page size requested.
     * @type {number}
     * @memberof StateEntityNonFungiblesPageRequest
     */
    limit_per_page?: number | null;
    /**
     * Bech32m-encoded human readable version of the address.
     * @type {string}
     * @memberof StateEntityNonFungiblesPageRequest
     */
    address: string;
    /**
     * 
     * @type {ResourceAggregationLevel}
     * @memberof StateEntityNonFungiblesPageRequest
     */
    aggregation_level?: ResourceAggregationLevel;
    /**
     * 
     * @type {StateEntityNonFungiblesPageRequestOptIns}
     * @memberof StateEntityNonFungiblesPageRequest
     */
    opt_ins?: StateEntityNonFungiblesPageRequestOptIns;
}

/**
 * Check if a given object implements the StateEntityNonFungiblesPageRequest interface.
 */
export function instanceOfStateEntityNonFungiblesPageRequest(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "address" in value;

    return isInstance;
}

export function StateEntityNonFungiblesPageRequestFromJSON(json: any): StateEntityNonFungiblesPageRequest {
    return StateEntityNonFungiblesPageRequestFromJSONTyped(json, false);
}

export function StateEntityNonFungiblesPageRequestFromJSONTyped(json: any, ignoreDiscriminator: boolean): StateEntityNonFungiblesPageRequest {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'at_ledger_state': !exists(json, 'at_ledger_state') ? undefined : LedgerStateSelectorFromJSON(json['at_ledger_state']),
        'cursor': !exists(json, 'cursor') ? undefined : json['cursor'],
        'limit_per_page': !exists(json, 'limit_per_page') ? undefined : json['limit_per_page'],
        'address': json['address'],
        'aggregation_level': !exists(json, 'aggregation_level') ? undefined : ResourceAggregationLevelFromJSON(json['aggregation_level']),
        'opt_ins': !exists(json, 'opt_ins') ? undefined : StateEntityNonFungiblesPageRequestOptInsFromJSON(json['opt_ins']),
    };
}

export function StateEntityNonFungiblesPageRequestToJSON(value?: StateEntityNonFungiblesPageRequest | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'at_ledger_state': LedgerStateSelectorToJSON(value.at_ledger_state),
        'cursor': value.cursor,
        'limit_per_page': value.limit_per_page,
        'address': value.address,
        'aggregation_level': ResourceAggregationLevelToJSON(value.aggregation_level),
        'opt_ins': StateEntityNonFungiblesPageRequestOptInsToJSON(value.opt_ins),
    };
}


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
import type { ResourceAggregationLevel } from './ResourceAggregationLevel';
import {
    ResourceAggregationLevelFromJSON,
    ResourceAggregationLevelFromJSONTyped,
    ResourceAggregationLevelToJSON,
} from './ResourceAggregationLevel';
import type { StateEntityDetailsOptIns } from './StateEntityDetailsOptIns';
import {
    StateEntityDetailsOptInsFromJSON,
    StateEntityDetailsOptInsFromJSONTyped,
    StateEntityDetailsOptInsToJSON,
} from './StateEntityDetailsOptIns';

/**
 * 
 * @export
 * @interface StateEntityDetailsRequestAllOf
 */
export interface StateEntityDetailsRequestAllOf {
    /**
     * 
     * @type {StateEntityDetailsOptIns}
     * @memberof StateEntityDetailsRequestAllOf
     */
    opt_ins?: StateEntityDetailsOptIns;
    /**
     * 
     * @type {Array<string>}
     * @memberof StateEntityDetailsRequestAllOf
     */
    addresses: Array<string>;
    /**
     * 
     * @type {ResourceAggregationLevel}
     * @memberof StateEntityDetailsRequestAllOf
     */
    aggregation_level?: ResourceAggregationLevel;
}

/**
 * Check if a given object implements the StateEntityDetailsRequestAllOf interface.
 */
export function instanceOfStateEntityDetailsRequestAllOf(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "addresses" in value;

    return isInstance;
}

export function StateEntityDetailsRequestAllOfFromJSON(json: any): StateEntityDetailsRequestAllOf {
    return StateEntityDetailsRequestAllOfFromJSONTyped(json, false);
}

export function StateEntityDetailsRequestAllOfFromJSONTyped(json: any, ignoreDiscriminator: boolean): StateEntityDetailsRequestAllOf {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'opt_ins': !exists(json, 'opt_ins') ? undefined : StateEntityDetailsOptInsFromJSON(json['opt_ins']),
        'addresses': json['addresses'],
        'aggregation_level': !exists(json, 'aggregation_level') ? undefined : ResourceAggregationLevelFromJSON(json['aggregation_level']),
    };
}

export function StateEntityDetailsRequestAllOfToJSON(value?: StateEntityDetailsRequestAllOf | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'opt_ins': StateEntityDetailsOptInsToJSON(value.opt_ins),
        'addresses': value.addresses,
        'aggregation_level': ResourceAggregationLevelToJSON(value.aggregation_level),
    };
}


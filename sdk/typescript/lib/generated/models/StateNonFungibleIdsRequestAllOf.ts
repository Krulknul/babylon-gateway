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
 * 
 * @export
 * @interface StateNonFungibleIdsRequestAllOf
 */
export interface StateNonFungibleIdsRequestAllOf {
    /**
     * Bech32m-encoded human readable version of the address.
     * @type {string}
     * @memberof StateNonFungibleIdsRequestAllOf
     */
    resource_address: string;
}

/**
 * Check if a given object implements the StateNonFungibleIdsRequestAllOf interface.
 */
export function instanceOfStateNonFungibleIdsRequestAllOf(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "resource_address" in value;

    return isInstance;
}

export function StateNonFungibleIdsRequestAllOfFromJSON(json: any): StateNonFungibleIdsRequestAllOf {
    return StateNonFungibleIdsRequestAllOfFromJSONTyped(json, false);
}

export function StateNonFungibleIdsRequestAllOfFromJSONTyped(json: any, ignoreDiscriminator: boolean): StateNonFungibleIdsRequestAllOf {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'resource_address': json['resource_address'],
    };
}

export function StateNonFungibleIdsRequestAllOfToJSON(value?: StateNonFungibleIdsRequestAllOf | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'resource_address': value.resource_address,
    };
}


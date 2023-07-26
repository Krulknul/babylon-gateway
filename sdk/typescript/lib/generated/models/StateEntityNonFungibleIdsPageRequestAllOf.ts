/* tslint:disable */
/* eslint-disable */
/**
 * Babylon Gateway API - RCnet V2
 * This API is exposed by the Babylon Radix Gateway to enable clients to efficiently query current and historic state on the RadixDLT ledger, and intelligently handle transaction submission.  It is designed for use by wallets and explorers. For simple use cases, you can typically use the Core API on a Node. A Gateway is only needed for reading historic snapshots of ledger states or a more robust set-up.  The Gateway API is implemented by the [Network Gateway](https://github.com/radixdlt/babylon-gateway), which is configured to read from [full node(s)](https://github.com/radixdlt/babylon-node) to extract and index data from the network.  This document is an API reference documentation, visit [User Guide](https://docs-babylon.radixdlt.com/) to learn more about how to run a Gateway of your own.  ## Integration and forward compatibility guarantees  We give no guarantees that other endpoints will not change before Babylon mainnet launch, although changes are expected to be minimal. 
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
 * @interface StateEntityNonFungibleIdsPageRequestAllOf
 */
export interface StateEntityNonFungibleIdsPageRequestAllOf {
    /**
     * Bech32m-encoded human readable version of the address.
     * @type {string}
     * @memberof StateEntityNonFungibleIdsPageRequestAllOf
     */
    address: string;
    /**
     * Bech32m-encoded human readable version of the address.
     * @type {string}
     * @memberof StateEntityNonFungibleIdsPageRequestAllOf
     */
    vault_address: string;
    /**
     * Bech32m-encoded human readable version of the address.
     * @type {string}
     * @memberof StateEntityNonFungibleIdsPageRequestAllOf
     */
    resource_address: string;
}

/**
 * Check if a given object implements the StateEntityNonFungibleIdsPageRequestAllOf interface.
 */
export function instanceOfStateEntityNonFungibleIdsPageRequestAllOf(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "address" in value;
    isInstance = isInstance && "vault_address" in value;
    isInstance = isInstance && "resource_address" in value;

    return isInstance;
}

export function StateEntityNonFungibleIdsPageRequestAllOfFromJSON(json: any): StateEntityNonFungibleIdsPageRequestAllOf {
    return StateEntityNonFungibleIdsPageRequestAllOfFromJSONTyped(json, false);
}

export function StateEntityNonFungibleIdsPageRequestAllOfFromJSONTyped(json: any, ignoreDiscriminator: boolean): StateEntityNonFungibleIdsPageRequestAllOf {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'address': json['address'],
        'vault_address': json['vault_address'],
        'resource_address': json['resource_address'],
    };
}

export function StateEntityNonFungibleIdsPageRequestAllOfToJSON(value?: StateEntityNonFungibleIdsPageRequestAllOf | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'address': value.address,
        'vault_address': value.vault_address,
        'resource_address': value.resource_address,
    };
}


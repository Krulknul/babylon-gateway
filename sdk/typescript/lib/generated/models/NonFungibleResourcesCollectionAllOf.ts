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
import type { NonFungibleResourcesCollectionItem } from './NonFungibleResourcesCollectionItem';
import {
    NonFungibleResourcesCollectionItemFromJSON,
    NonFungibleResourcesCollectionItemFromJSONTyped,
    NonFungibleResourcesCollectionItemToJSON,
} from './NonFungibleResourcesCollectionItem';

/**
 * 
 * @export
 * @interface NonFungibleResourcesCollectionAllOf
 */
export interface NonFungibleResourcesCollectionAllOf {
    /**
     * 
     * @type {Array<NonFungibleResourcesCollectionItem>}
     * @memberof NonFungibleResourcesCollectionAllOf
     */
    items: Array<NonFungibleResourcesCollectionItem>;
}

/**
 * Check if a given object implements the NonFungibleResourcesCollectionAllOf interface.
 */
export function instanceOfNonFungibleResourcesCollectionAllOf(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "items" in value;

    return isInstance;
}

export function NonFungibleResourcesCollectionAllOfFromJSON(json: any): NonFungibleResourcesCollectionAllOf {
    return NonFungibleResourcesCollectionAllOfFromJSONTyped(json, false);
}

export function NonFungibleResourcesCollectionAllOfFromJSONTyped(json: any, ignoreDiscriminator: boolean): NonFungibleResourcesCollectionAllOf {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'items': ((json['items'] as Array<any>).map(NonFungibleResourcesCollectionItemFromJSON)),
    };
}

export function NonFungibleResourcesCollectionAllOfToJSON(value?: NonFungibleResourcesCollectionAllOf | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'items': ((value.items as Array<any>).map(NonFungibleResourcesCollectionItemToJSON)),
    };
}


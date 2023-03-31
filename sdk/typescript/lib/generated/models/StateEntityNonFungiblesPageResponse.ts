/* tslint:disable */
/* eslint-disable */
/**
 * Radix Babylon Gateway API
 * This API is designed to enable clients to efficiently query information on the RadixDLT ledger, and allow clients to build and submit transactions to the network. It is designed for use by wallets and explorers.  This document is an API reference documentation, visit [User Guide](https://docs.radixdlt.com/main/apis/gateway-api.html) to learn more about different usage scenarios.  The Gateway API is implemented by the [Network Gateway](https://github.com/radixdlt/babylon-gateway), which is configured to read from [full node(s)](https://github.com/radixdlt/babylon-node) to extract and index data from the network. 
 *
 * The version of the OpenAPI document: 0.1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
import type { LedgerState } from './LedgerState';
import {
    LedgerStateFromJSON,
    LedgerStateFromJSONTyped,
    LedgerStateToJSON,
} from './LedgerState';
import type { NonFungibleResourcesCollectionItem } from './NonFungibleResourcesCollectionItem';
import {
    NonFungibleResourcesCollectionItemFromJSON,
    NonFungibleResourcesCollectionItemFromJSONTyped,
    NonFungibleResourcesCollectionItemToJSON,
} from './NonFungibleResourcesCollectionItem';

/**
 * 
 * @export
 * @interface StateEntityNonFungiblesPageResponse
 */
export interface StateEntityNonFungiblesPageResponse {
    /**
     * 
     * @type {LedgerState}
     * @memberof StateEntityNonFungiblesPageResponse
     */
    ledger_state: LedgerState;
    /**
     * Total number of items in underlying collection, fragment of which is available in `items` collection.
     * @type {number}
     * @memberof StateEntityNonFungiblesPageResponse
     */
    total_count?: number | null;
    /**
     * If specified, contains a cursor to query previous page of the `items` collection.
     * @type {string}
     * @memberof StateEntityNonFungiblesPageResponse
     */
    previous_cursor?: string | null;
    /**
     * If specified, contains a cursor to query next page of the `items` collection.
     * @type {string}
     * @memberof StateEntityNonFungiblesPageResponse
     */
    next_cursor?: string | null;
    /**
     * 
     * @type {Array<NonFungibleResourcesCollectionItem>}
     * @memberof StateEntityNonFungiblesPageResponse
     */
    items: Array<NonFungibleResourcesCollectionItem>;
    /**
     * Bech32m-encoded human readable version of the entity's global address or hex-encoded id.
     * @type {string}
     * @memberof StateEntityNonFungiblesPageResponse
     */
    address: string;
}

/**
 * Check if a given object implements the StateEntityNonFungiblesPageResponse interface.
 */
export function instanceOfStateEntityNonFungiblesPageResponse(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "ledger_state" in value;
    isInstance = isInstance && "items" in value;
    isInstance = isInstance && "address" in value;

    return isInstance;
}

export function StateEntityNonFungiblesPageResponseFromJSON(json: any): StateEntityNonFungiblesPageResponse {
    return StateEntityNonFungiblesPageResponseFromJSONTyped(json, false);
}

export function StateEntityNonFungiblesPageResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): StateEntityNonFungiblesPageResponse {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'ledger_state': LedgerStateFromJSON(json['ledger_state']),
        'total_count': !exists(json, 'total_count') ? undefined : json['total_count'],
        'previous_cursor': !exists(json, 'previous_cursor') ? undefined : json['previous_cursor'],
        'next_cursor': !exists(json, 'next_cursor') ? undefined : json['next_cursor'],
        'items': ((json['items'] as Array<any>).map(NonFungibleResourcesCollectionItemFromJSON)),
        'address': json['address'],
    };
}

export function StateEntityNonFungiblesPageResponseToJSON(value?: StateEntityNonFungiblesPageResponse | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'ledger_state': LedgerStateToJSON(value.ledger_state),
        'total_count': value.total_count,
        'previous_cursor': value.previous_cursor,
        'next_cursor': value.next_cursor,
        'items': ((value.items as Array<any>).map(NonFungibleResourcesCollectionItemToJSON)),
        'address': value.address,
    };
}


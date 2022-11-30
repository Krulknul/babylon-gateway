/* tslint:disable */
/* eslint-disable */
/**
 * Radix Babylon Gateway API
 * See https://docs.radixdlt.com/main/apis/introduction.html 
 *
 * The version of the OpenAPI document: 2.0.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
import type { NonFungibleIdsCollectionItem } from './NonFungibleIdsCollectionItem';
import {
    NonFungibleIdsCollectionItemFromJSON,
    NonFungibleIdsCollectionItemFromJSONTyped,
    NonFungibleIdsCollectionItemToJSON,
} from './NonFungibleIdsCollectionItem';

/**
 * 
 * @export
 * @interface NonFungibleIdsCollectionAllOf
 */
export interface NonFungibleIdsCollectionAllOf {
    /**
     * 
     * @type {Array<NonFungibleIdsCollectionItem>}
     * @memberof NonFungibleIdsCollectionAllOf
     */
    items: Array<NonFungibleIdsCollectionItem>;
}

/**
 * Check if a given object implements the NonFungibleIdsCollectionAllOf interface.
 */
export function instanceOfNonFungibleIdsCollectionAllOf(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "items" in value;

    return isInstance;
}

export function NonFungibleIdsCollectionAllOfFromJSON(json: any): NonFungibleIdsCollectionAllOf {
    return NonFungibleIdsCollectionAllOfFromJSONTyped(json, false);
}

export function NonFungibleIdsCollectionAllOfFromJSONTyped(json: any, ignoreDiscriminator: boolean): NonFungibleIdsCollectionAllOf {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'items': ((json['items'] as Array<any>).map(NonFungibleIdsCollectionItemFromJSON)),
    };
}

export function NonFungibleIdsCollectionAllOfToJSON(value?: NonFungibleIdsCollectionAllOf | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'items': ((value.items as Array<any>).map(NonFungibleIdsCollectionItemToJSON)),
    };
}


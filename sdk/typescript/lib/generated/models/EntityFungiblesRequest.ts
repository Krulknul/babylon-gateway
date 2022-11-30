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
import type { PartialLedgerStateIdentifier } from './PartialLedgerStateIdentifier';
import {
    PartialLedgerStateIdentifierFromJSON,
    PartialLedgerStateIdentifierFromJSONTyped,
    PartialLedgerStateIdentifierToJSON,
} from './PartialLedgerStateIdentifier';

/**
 * 
 * @export
 * @interface EntityFungiblesRequest
 */
export interface EntityFungiblesRequest {
    /**
     * The Bech32m-encoded human readable version of the entity's global address.
     * @type {string}
     * @memberof EntityFungiblesRequest
     */
    address: string;
    /**
     * 
     * @type {PartialLedgerStateIdentifier}
     * @memberof EntityFungiblesRequest
     */
    at_state_identifier?: PartialLedgerStateIdentifier | null;
    /**
     * This cursor allows forward pagination, by providing the cursor from the previous request.
     * @type {string}
     * @memberof EntityFungiblesRequest
     */
    cursor?: string | null;
    /**
     * The page size requested.
     * @type {number}
     * @memberof EntityFungiblesRequest
     */
    limit?: number | null;
}

/**
 * Check if a given object implements the EntityFungiblesRequest interface.
 */
export function instanceOfEntityFungiblesRequest(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "address" in value;

    return isInstance;
}

export function EntityFungiblesRequestFromJSON(json: any): EntityFungiblesRequest {
    return EntityFungiblesRequestFromJSONTyped(json, false);
}

export function EntityFungiblesRequestFromJSONTyped(json: any, ignoreDiscriminator: boolean): EntityFungiblesRequest {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'address': json['address'],
        'at_state_identifier': !exists(json, 'at_state_identifier') ? undefined : PartialLedgerStateIdentifierFromJSON(json['at_state_identifier']),
        'cursor': !exists(json, 'cursor') ? undefined : json['cursor'],
        'limit': !exists(json, 'limit') ? undefined : json['limit'],
    };
}

export function EntityFungiblesRequestToJSON(value?: EntityFungiblesRequest | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'address': value.address,
        'at_state_identifier': PartialLedgerStateIdentifierToJSON(value.at_state_identifier),
        'cursor': value.cursor,
        'limit': value.limit,
    };
}


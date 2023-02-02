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
import type { ValidatorCollection } from './ValidatorCollection';
import {
    ValidatorCollectionFromJSON,
    ValidatorCollectionFromJSONTyped,
    ValidatorCollectionToJSON,
} from './ValidatorCollection';

/**
 * 
 * @export
 * @interface StateValidatorsListResponse
 */
export interface StateValidatorsListResponse {
    /**
     * 
     * @type {LedgerState}
     * @memberof StateValidatorsListResponse
     */
    ledger_state: LedgerState;
    /**
     * 
     * @type {ValidatorCollection}
     * @memberof StateValidatorsListResponse
     */
    validators: ValidatorCollection;
}

/**
 * Check if a given object implements the StateValidatorsListResponse interface.
 */
export function instanceOfStateValidatorsListResponse(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "ledger_state" in value;
    isInstance = isInstance && "validators" in value;

    return isInstance;
}

export function StateValidatorsListResponseFromJSON(json: any): StateValidatorsListResponse {
    return StateValidatorsListResponseFromJSONTyped(json, false);
}

export function StateValidatorsListResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): StateValidatorsListResponse {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'ledger_state': LedgerStateFromJSON(json['ledger_state']),
        'validators': ValidatorCollectionFromJSON(json['validators']),
    };
}

export function StateValidatorsListResponseToJSON(value?: StateValidatorsListResponse | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'ledger_state': LedgerStateToJSON(value.ledger_state),
        'validators': ValidatorCollectionToJSON(value.validators),
    };
}


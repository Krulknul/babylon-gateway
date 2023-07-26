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
import type { MetadataNonFungibleGlobalIdArrayValueAllOfValues } from './MetadataNonFungibleGlobalIdArrayValueAllOfValues';
import {
    MetadataNonFungibleGlobalIdArrayValueAllOfValuesFromJSON,
    MetadataNonFungibleGlobalIdArrayValueAllOfValuesFromJSONTyped,
    MetadataNonFungibleGlobalIdArrayValueAllOfValuesToJSON,
} from './MetadataNonFungibleGlobalIdArrayValueAllOfValues';

/**
 * 
 * @export
 * @interface MetadataNonFungibleGlobalIdArrayValue
 */
export interface MetadataNonFungibleGlobalIdArrayValue {
    /**
     * 
     * @type {string}
     * @memberof MetadataNonFungibleGlobalIdArrayValue
     */
    type: MetadataNonFungibleGlobalIdArrayValueTypeEnum;
    /**
     * 
     * @type {Array<MetadataNonFungibleGlobalIdArrayValueAllOfValues>}
     * @memberof MetadataNonFungibleGlobalIdArrayValue
     */
    values: Array<MetadataNonFungibleGlobalIdArrayValueAllOfValues>;
}


/**
 * @export
 */
export const MetadataNonFungibleGlobalIdArrayValueTypeEnum = {
    NonFungibleGlobalIdArray: 'NonFungibleGlobalIdArray'
} as const;
export type MetadataNonFungibleGlobalIdArrayValueTypeEnum = typeof MetadataNonFungibleGlobalIdArrayValueTypeEnum[keyof typeof MetadataNonFungibleGlobalIdArrayValueTypeEnum];


/**
 * Check if a given object implements the MetadataNonFungibleGlobalIdArrayValue interface.
 */
export function instanceOfMetadataNonFungibleGlobalIdArrayValue(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "type" in value;
    isInstance = isInstance && "values" in value;

    return isInstance;
}

export function MetadataNonFungibleGlobalIdArrayValueFromJSON(json: any): MetadataNonFungibleGlobalIdArrayValue {
    return MetadataNonFungibleGlobalIdArrayValueFromJSONTyped(json, false);
}

export function MetadataNonFungibleGlobalIdArrayValueFromJSONTyped(json: any, ignoreDiscriminator: boolean): MetadataNonFungibleGlobalIdArrayValue {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'type': json['type'],
        'values': ((json['values'] as Array<any>).map(MetadataNonFungibleGlobalIdArrayValueAllOfValuesFromJSON)),
    };
}

export function MetadataNonFungibleGlobalIdArrayValueToJSON(value?: MetadataNonFungibleGlobalIdArrayValue | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'type': value.type,
        'values': ((value.values as Array<any>).map(MetadataNonFungibleGlobalIdArrayValueAllOfValuesToJSON)),
    };
}


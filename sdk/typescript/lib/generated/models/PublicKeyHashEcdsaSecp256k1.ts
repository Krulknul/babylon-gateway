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
 * @interface PublicKeyHashEcdsaSecp256k1
 */
export interface PublicKeyHashEcdsaSecp256k1 {
    /**
     * 
     * @type {string}
     * @memberof PublicKeyHashEcdsaSecp256k1
     */
    key_hash_type: PublicKeyHashEcdsaSecp256k1KeyHashTypeEnum;
    /**
     * Hex-encoded SHA-256 hash.
     * @type {string}
     * @memberof PublicKeyHashEcdsaSecp256k1
     */
    hash_hex: string;
}


/**
 * @export
 */
export const PublicKeyHashEcdsaSecp256k1KeyHashTypeEnum = {
    EcdsaSecp256k1: 'EcdsaSecp256k1'
} as const;
export type PublicKeyHashEcdsaSecp256k1KeyHashTypeEnum = typeof PublicKeyHashEcdsaSecp256k1KeyHashTypeEnum[keyof typeof PublicKeyHashEcdsaSecp256k1KeyHashTypeEnum];


/**
 * Check if a given object implements the PublicKeyHashEcdsaSecp256k1 interface.
 */
export function instanceOfPublicKeyHashEcdsaSecp256k1(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "key_hash_type" in value;
    isInstance = isInstance && "hash_hex" in value;

    return isInstance;
}

export function PublicKeyHashEcdsaSecp256k1FromJSON(json: any): PublicKeyHashEcdsaSecp256k1 {
    return PublicKeyHashEcdsaSecp256k1FromJSONTyped(json, false);
}

export function PublicKeyHashEcdsaSecp256k1FromJSONTyped(json: any, ignoreDiscriminator: boolean): PublicKeyHashEcdsaSecp256k1 {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'key_hash_type': json['key_hash_type'],
        'hash_hex': json['hash_hex'],
    };
}

export function PublicKeyHashEcdsaSecp256k1ToJSON(value?: PublicKeyHashEcdsaSecp256k1 | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'key_hash_type': value.key_hash_type,
        'hash_hex': value.hash_hex,
    };
}


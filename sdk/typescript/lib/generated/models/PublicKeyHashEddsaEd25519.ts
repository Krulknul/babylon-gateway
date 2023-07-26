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
/**
 * 
 * @export
 * @interface PublicKeyHashEddsaEd25519
 */
export interface PublicKeyHashEddsaEd25519 {
    /**
     * 
     * @type {string}
     * @memberof PublicKeyHashEddsaEd25519
     */
    key_hash_type: PublicKeyHashEddsaEd25519KeyHashTypeEnum;
    /**
     * Hex-encoded SHA-256 hash.
     * @type {string}
     * @memberof PublicKeyHashEddsaEd25519
     */
    hash_hex: string;
}


/**
 * @export
 */
export const PublicKeyHashEddsaEd25519KeyHashTypeEnum = {
    EddsaEd25519: 'EddsaEd25519'
} as const;
export type PublicKeyHashEddsaEd25519KeyHashTypeEnum = typeof PublicKeyHashEddsaEd25519KeyHashTypeEnum[keyof typeof PublicKeyHashEddsaEd25519KeyHashTypeEnum];


/**
 * Check if a given object implements the PublicKeyHashEddsaEd25519 interface.
 */
export function instanceOfPublicKeyHashEddsaEd25519(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "key_hash_type" in value;
    isInstance = isInstance && "hash_hex" in value;

    return isInstance;
}

export function PublicKeyHashEddsaEd25519FromJSON(json: any): PublicKeyHashEddsaEd25519 {
    return PublicKeyHashEddsaEd25519FromJSONTyped(json, false);
}

export function PublicKeyHashEddsaEd25519FromJSONTyped(json: any, ignoreDiscriminator: boolean): PublicKeyHashEddsaEd25519 {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'key_hash_type': json['key_hash_type'],
        'hash_hex': json['hash_hex'],
    };
}

export function PublicKeyHashEddsaEd25519ToJSON(value?: PublicKeyHashEddsaEd25519 | null): any {
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


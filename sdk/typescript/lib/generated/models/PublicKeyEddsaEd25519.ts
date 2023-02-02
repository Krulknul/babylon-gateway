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
import type { PublicKey } from './PublicKey';
import {
    PublicKeyFromJSON,
    PublicKeyFromJSONTyped,
    PublicKeyToJSON,
} from './PublicKey';
import type { PublicKeyType } from './PublicKeyType';
import {
    PublicKeyTypeFromJSON,
    PublicKeyTypeFromJSONTyped,
    PublicKeyTypeToJSON,
} from './PublicKeyType';

/**
 * 
 * @export
 * @interface PublicKeyEddsaEd25519
 */
export interface PublicKeyEddsaEd25519 extends PublicKey {
    /**
     * The hex-encoded compressed EdDSA Ed25519 public key (32 bytes)
     * @type {string}
     * @memberof PublicKeyEddsaEd25519
     */
    key_hex: string;
}

/**
 * Check if a given object implements the PublicKeyEddsaEd25519 interface.
 */
export function instanceOfPublicKeyEddsaEd25519(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "key_hex" in value;

    return isInstance;
}

export function PublicKeyEddsaEd25519FromJSON(json: any): PublicKeyEddsaEd25519 {
    return PublicKeyEddsaEd25519FromJSONTyped(json, false);
}

export function PublicKeyEddsaEd25519FromJSONTyped(json: any, ignoreDiscriminator: boolean): PublicKeyEddsaEd25519 {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        ...PublicKeyFromJSONTyped(json, ignoreDiscriminator),
        'key_hex': json['key_hex'],
    };
}

export function PublicKeyEddsaEd25519ToJSON(value?: PublicKeyEddsaEd25519 | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        ...PublicKeyToJSON(value),
        'key_hex': value.key_hex,
    };
}


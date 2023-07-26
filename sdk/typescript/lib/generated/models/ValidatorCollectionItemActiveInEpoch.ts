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
import type { PublicKey } from './PublicKey';
import {
    PublicKeyFromJSON,
    PublicKeyFromJSONTyped,
    PublicKeyToJSON,
} from './PublicKey';

/**
 * 
 * @export
 * @interface ValidatorCollectionItemActiveInEpoch
 */
export interface ValidatorCollectionItemActiveInEpoch {
    /**
     * String-encoded decimal representing the amount of a related fungible resource.
     * @type {string}
     * @memberof ValidatorCollectionItemActiveInEpoch
     */
    stake: string;
    /**
     * 
     * @type {number}
     * @memberof ValidatorCollectionItemActiveInEpoch
     */
    stake_percentage: number;
    /**
     * 
     * @type {PublicKey}
     * @memberof ValidatorCollectionItemActiveInEpoch
     */
    key: PublicKey;
}

/**
 * Check if a given object implements the ValidatorCollectionItemActiveInEpoch interface.
 */
export function instanceOfValidatorCollectionItemActiveInEpoch(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "stake" in value;
    isInstance = isInstance && "stake_percentage" in value;
    isInstance = isInstance && "key" in value;

    return isInstance;
}

export function ValidatorCollectionItemActiveInEpochFromJSON(json: any): ValidatorCollectionItemActiveInEpoch {
    return ValidatorCollectionItemActiveInEpochFromJSONTyped(json, false);
}

export function ValidatorCollectionItemActiveInEpochFromJSONTyped(json: any, ignoreDiscriminator: boolean): ValidatorCollectionItemActiveInEpoch {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'stake': json['stake'],
        'stake_percentage': json['stake_percentage'],
        'key': PublicKeyFromJSON(json['key']),
    };
}

export function ValidatorCollectionItemActiveInEpochToJSON(value?: ValidatorCollectionItemActiveInEpoch | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'stake': value.stake,
        'stake_percentage': value.stake_percentage,
        'key': PublicKeyToJSON(value.key),
    };
}


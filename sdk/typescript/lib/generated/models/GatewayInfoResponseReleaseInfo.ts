/* tslint:disable */
/* eslint-disable */
/**
 * Babylon Gateway API - RCnet V3
 * This API is exposed by the Babylon Radix Gateway to enable clients to efficiently query current and historic state on the RadixDLT ledger, and intelligently handle transaction submission.  It is designed for use by wallets and explorers. For simple use cases, you can typically use the Core API on a Node. A Gateway is only needed for reading historic snapshots of ledger states or a more robust set-up.  The Gateway API is implemented by the [Network Gateway](https://github.com/radixdlt/babylon-gateway), which is configured to read from [full node(s)](https://github.com/radixdlt/babylon-node) to extract and index data from the network.  This document is an API reference documentation, visit [User Guide](https://docs-babylon.radixdlt.com/) to learn more about how to run a Gateway of your own.  ## Migration guide  Please see [the latest release notes](https://github.com/radixdlt/babylon-gateway/releases).  ## Integration and forward compatibility guarantees  We give no guarantees that other endpoints will not change before Babylon mainnet launch, although changes are expected to be minimal. 
 *
 * The version of the OpenAPI document: 0.5.0
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
 * @interface GatewayInfoResponseReleaseInfo
 */
export interface GatewayInfoResponseReleaseInfo {
    /**
     * The release that is currently deployed to the Gateway API.
     * @type {string}
     * @memberof GatewayInfoResponseReleaseInfo
     */
    release_version: string;
    /**
     * The Open API Schema version that was used to generate the API models.
     * @type {string}
     * @memberof GatewayInfoResponseReleaseInfo
     */
    open_api_schema_version: string;
    /**
     * Image tag that is currently deployed to the Gateway API.
     * @type {string}
     * @memberof GatewayInfoResponseReleaseInfo
     */
    image_tag: string;
}

/**
 * Check if a given object implements the GatewayInfoResponseReleaseInfo interface.
 */
export function instanceOfGatewayInfoResponseReleaseInfo(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "release_version" in value;
    isInstance = isInstance && "open_api_schema_version" in value;
    isInstance = isInstance && "image_tag" in value;

    return isInstance;
}

export function GatewayInfoResponseReleaseInfoFromJSON(json: any): GatewayInfoResponseReleaseInfo {
    return GatewayInfoResponseReleaseInfoFromJSONTyped(json, false);
}

export function GatewayInfoResponseReleaseInfoFromJSONTyped(json: any, ignoreDiscriminator: boolean): GatewayInfoResponseReleaseInfo {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'release_version': json['release_version'],
        'open_api_schema_version': json['open_api_schema_version'],
        'image_tag': json['image_tag'],
    };
}

export function GatewayInfoResponseReleaseInfoToJSON(value?: GatewayInfoResponseReleaseInfo | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'release_version': value.release_version,
        'open_api_schema_version': value.open_api_schema_version,
        'image_tag': value.image_tag,
    };
}


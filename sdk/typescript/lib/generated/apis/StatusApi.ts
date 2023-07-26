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


import * as runtime from '../runtime';
import type {
  GatewayStatusResponse,
  NetworkConfigurationResponse,
} from '../models';
import {
    GatewayStatusResponseFromJSON,
    GatewayStatusResponseToJSON,
    NetworkConfigurationResponseFromJSON,
    NetworkConfigurationResponseToJSON,
} from '../models';

/**
 * 
 */
export class StatusApi extends runtime.BaseAPI {

    /**
     * Returns the Gateway API version and current ledger state. 
     * Get Gateway Status
     */
    async gatewayStatusRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<GatewayStatusResponse>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/status/gateway-status`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => GatewayStatusResponseFromJSON(jsonValue));
    }

    /**
     * Returns the Gateway API version and current ledger state. 
     * Get Gateway Status
     */
    async gatewayStatus(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<GatewayStatusResponse> {
        const response = await this.gatewayStatusRaw(initOverrides);
        return await response.value();
    }

    /**
     * Returns network identifier, network name and well-known network addresses. 
     * Get Network Configuration
     */
    async networkConfigurationRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<NetworkConfigurationResponse>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/status/network-configuration`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => NetworkConfigurationResponseFromJSON(jsonValue));
    }

    /**
     * Returns network identifier, network name and well-known network addresses. 
     * Get Network Configuration
     */
    async networkConfiguration(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<NetworkConfigurationResponse> {
        const response = await this.networkConfigurationRaw(initOverrides);
        return await response.value();
    }

}

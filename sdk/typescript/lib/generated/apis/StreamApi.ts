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


import * as runtime from '../runtime';
import type {
  ErrorResponse,
  StreamTransactionsRequest,
  StreamTransactionsResponse,
} from '../models';
import {
    ErrorResponseFromJSON,
    ErrorResponseToJSON,
    StreamTransactionsRequestFromJSON,
    StreamTransactionsRequestToJSON,
    StreamTransactionsResponseFromJSON,
    StreamTransactionsResponseToJSON,
} from '../models';

export interface StreamTransactionsOperationRequest {
    streamTransactionsRequest: StreamTransactionsRequest;
}

/**
 * 
 */
export class StreamApi extends runtime.BaseAPI {

    /**
     * Returns transactions which have been committed to the ledger. 
     * Get Transactions Stream
     */
    async streamTransactionsRaw(requestParameters: StreamTransactionsOperationRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StreamTransactionsResponse>> {
        if (requestParameters.streamTransactionsRequest === null || requestParameters.streamTransactionsRequest === undefined) {
            throw new runtime.RequiredError('streamTransactionsRequest','Required parameter requestParameters.streamTransactionsRequest was null or undefined when calling streamTransactions.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/stream/transactions`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: StreamTransactionsRequestToJSON(requestParameters.streamTransactionsRequest),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StreamTransactionsResponseFromJSON(jsonValue));
    }

    /**
     * Returns transactions which have been committed to the ledger. 
     * Get Transactions Stream
     */
    async streamTransactions(requestParameters: StreamTransactionsOperationRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StreamTransactionsResponse> {
        const response = await this.streamTransactionsRaw(requestParameters, initOverrides);
        return await response.value();
    }

}

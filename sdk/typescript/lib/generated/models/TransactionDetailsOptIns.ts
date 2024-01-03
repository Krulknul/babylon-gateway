/* tslint:disable */
/* eslint-disable */
/**
 * Radix Gateway API - Babylon
 * This API is exposed by the Babylon Radix Gateway to enable clients to efficiently query current and historic state on the RadixDLT ledger, and intelligently handle transaction submission.  It is designed for use by wallets and explorers, and for light queries from front-end dApps. For exchange/asset integrations, back-end dApp integrations, or simple use cases, you should consider using the Core API on a Node. A Gateway is only needed for reading historic snapshots of ledger states or a more robust set-up.  The Gateway API is implemented by the [Network Gateway](https://github.com/radixdlt/babylon-gateway), which is configured to read from [full node(s)](https://github.com/radixdlt/babylon-node) to extract and index data from the network.  This document is an API reference documentation, visit [User Guide](https://docs.radixdlt.com/) to learn more about how to run a Gateway of your own.  ## Migration guide  Please see [the latest release notes](https://github.com/radixdlt/babylon-gateway/releases).  ## Integration and forward compatibility guarantees  All responses may have additional fields added at any release, so clients are advised to use JSON parsers which ignore unknown fields on JSON objects.  When the Radix protocol is updated, new functionality may be added, and so discriminated unions returned by the API may need to be updated to have new variants added, corresponding to the updated data. Clients may need to update in advance to be able to handle these new variants when a protocol update comes out.  On the very rare occasions we need to make breaking changes to the API, these will be warned in advance with deprecation notices on previous versions. These deprecation notices will include a safe migration path. Deprecation notes or breaking changes will be flagged clearly in release notes for new versions of the Gateway.  The Gateway DB schema is not subject to any compatibility guarantees, and may be changed at any release. DB changes will be flagged in the release notes so clients doing custom DB integrations can prepare. 
 *
 * The version of the OpenAPI document: v1.2.2
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
 * @interface TransactionDetailsOptIns
 */
export interface TransactionDetailsOptIns {
    /**
     * if set to `true`, raw transaction hex is returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    raw_hex?: boolean;
    /**
     * if set to `true`, state changes inside receipt object are returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    receipt_state_changes?: boolean;
    /**
     * if set to `true`, fee summary inside receipt object is returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    receipt_fee_summary?: boolean;
    /**
     * if set to `true`, fee source inside receipt object is returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    receipt_fee_source?: boolean;
    /**
     * if set to `true`, fee destination inside receipt object is returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    receipt_fee_destination?: boolean;
    /**
     * if set to `true`, costing parameters inside receipt object is returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    receipt_costing_parameters?: boolean;
    /**
     * if set to `true`, events inside receipt object is returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    receipt_events?: boolean;
    /**
     * (true by default) if set to `true`, transaction receipt output is returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    receipt_output?: boolean;
    /**
     * if set to `true`, all affected global entities by given transaction are returned.
     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    affected_global_entities?: boolean;
    /**
     * if set to `true`, returns the fungible and non-fungible balance changes.

**Warning!** This opt-in might be missing for recently committed transactions, in that case a `null` value will be returned. Retry the request until non-null value is returned.

     * @type {boolean}
     * @memberof TransactionDetailsOptIns
     */
    balance_changes?: boolean;
}

/**
 * Check if a given object implements the TransactionDetailsOptIns interface.
 */
export function instanceOfTransactionDetailsOptIns(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function TransactionDetailsOptInsFromJSON(json: any): TransactionDetailsOptIns {
    return TransactionDetailsOptInsFromJSONTyped(json, false);
}

export function TransactionDetailsOptInsFromJSONTyped(json: any, ignoreDiscriminator: boolean): TransactionDetailsOptIns {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'raw_hex': !exists(json, 'raw_hex') ? undefined : json['raw_hex'],
        'receipt_state_changes': !exists(json, 'receipt_state_changes') ? undefined : json['receipt_state_changes'],
        'receipt_fee_summary': !exists(json, 'receipt_fee_summary') ? undefined : json['receipt_fee_summary'],
        'receipt_fee_source': !exists(json, 'receipt_fee_source') ? undefined : json['receipt_fee_source'],
        'receipt_fee_destination': !exists(json, 'receipt_fee_destination') ? undefined : json['receipt_fee_destination'],
        'receipt_costing_parameters': !exists(json, 'receipt_costing_parameters') ? undefined : json['receipt_costing_parameters'],
        'receipt_events': !exists(json, 'receipt_events') ? undefined : json['receipt_events'],
        'receipt_output': !exists(json, 'receipt_output') ? undefined : json['receipt_output'],
        'affected_global_entities': !exists(json, 'affected_global_entities') ? undefined : json['affected_global_entities'],
        'balance_changes': !exists(json, 'balance_changes') ? undefined : json['balance_changes'],
    };
}

export function TransactionDetailsOptInsToJSON(value?: TransactionDetailsOptIns | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'raw_hex': value.raw_hex,
        'receipt_state_changes': value.receipt_state_changes,
        'receipt_fee_summary': value.receipt_fee_summary,
        'receipt_fee_source': value.receipt_fee_source,
        'receipt_fee_destination': value.receipt_fee_destination,
        'receipt_costing_parameters': value.receipt_costing_parameters,
        'receipt_events': value.receipt_events,
        'receipt_output': value.receipt_output,
        'affected_global_entities': value.affected_global_entities,
        'balance_changes': value.balance_changes,
    };
}


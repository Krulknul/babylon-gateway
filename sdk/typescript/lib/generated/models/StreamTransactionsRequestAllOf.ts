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
import type { LedgerStateSelector } from './LedgerStateSelector';
import {
    LedgerStateSelectorFromJSON,
    LedgerStateSelectorFromJSONTyped,
    LedgerStateSelectorToJSON,
} from './LedgerStateSelector';
import type { StreamTransactionsRequestEventFilterItem } from './StreamTransactionsRequestEventFilterItem';
import {
    StreamTransactionsRequestEventFilterItemFromJSON,
    StreamTransactionsRequestEventFilterItemFromJSONTyped,
    StreamTransactionsRequestEventFilterItemToJSON,
} from './StreamTransactionsRequestEventFilterItem';
import type { TransactionCommittedDetailsOptIns } from './TransactionCommittedDetailsOptIns';
import {
    TransactionCommittedDetailsOptInsFromJSON,
    TransactionCommittedDetailsOptInsFromJSONTyped,
    TransactionCommittedDetailsOptInsToJSON,
} from './TransactionCommittedDetailsOptIns';

/**
 * 
 * @export
 * @interface StreamTransactionsRequestAllOf
 */
export interface StreamTransactionsRequestAllOf {
    /**
     * 
     * @type {LedgerStateSelector}
     * @memberof StreamTransactionsRequestAllOf
     */
    from_ledger_state?: LedgerStateSelector | null;
    /**
     * Limit returned transactions by their kind. Defaults to `user`.
     * @type {string}
     * @memberof StreamTransactionsRequestAllOf
     */
    kind_filter?: StreamTransactionsRequestAllOfKindFilterEnum;
    /**
     * 
     * @type {Array<string>}
     * @memberof StreamTransactionsRequestAllOf
     */
    manifest_accounts_withdrawn_from_filter?: Array<string>;
    /**
     * 
     * @type {Array<string>}
     * @memberof StreamTransactionsRequestAllOf
     */
    manifest_accounts_deposited_into_filter?: Array<string>;
    /**
     * 
     * @type {Array<string>}
     * @memberof StreamTransactionsRequestAllOf
     */
    manifest_resources_filter?: Array<string>;
    /**
     * 
     * @type {Array<string>}
     * @memberof StreamTransactionsRequestAllOf
     */
    affected_global_entities_filter?: Array<string>;
    /**
     * 
     * @type {Array<StreamTransactionsRequestEventFilterItem>}
     * @memberof StreamTransactionsRequestAllOf
     */
    events_filter?: Array<StreamTransactionsRequestEventFilterItem>;
    /**
     * Configures the order of returned result set. Defaults to `desc`.
     * @type {string}
     * @memberof StreamTransactionsRequestAllOf
     */
    order?: StreamTransactionsRequestAllOfOrderEnum;
    /**
     * 
     * @type {TransactionCommittedDetailsOptIns}
     * @memberof StreamTransactionsRequestAllOf
     */
    opt_ins?: TransactionCommittedDetailsOptIns;
}


/**
 * @export
 */
export const StreamTransactionsRequestAllOfKindFilterEnum = {
    User: 'User',
    EpochChange: 'EpochChange',
    All: 'All'
} as const;
export type StreamTransactionsRequestAllOfKindFilterEnum = typeof StreamTransactionsRequestAllOfKindFilterEnum[keyof typeof StreamTransactionsRequestAllOfKindFilterEnum];

/**
 * @export
 */
export const StreamTransactionsRequestAllOfOrderEnum = {
    Asc: 'Asc',
    Desc: 'Desc'
} as const;
export type StreamTransactionsRequestAllOfOrderEnum = typeof StreamTransactionsRequestAllOfOrderEnum[keyof typeof StreamTransactionsRequestAllOfOrderEnum];


/**
 * Check if a given object implements the StreamTransactionsRequestAllOf interface.
 */
export function instanceOfStreamTransactionsRequestAllOf(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function StreamTransactionsRequestAllOfFromJSON(json: any): StreamTransactionsRequestAllOf {
    return StreamTransactionsRequestAllOfFromJSONTyped(json, false);
}

export function StreamTransactionsRequestAllOfFromJSONTyped(json: any, ignoreDiscriminator: boolean): StreamTransactionsRequestAllOf {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'from_ledger_state': !exists(json, 'from_ledger_state') ? undefined : LedgerStateSelectorFromJSON(json['from_ledger_state']),
        'kind_filter': !exists(json, 'kind_filter') ? undefined : json['kind_filter'],
        'manifest_accounts_withdrawn_from_filter': !exists(json, 'manifest_accounts_withdrawn_from_filter') ? undefined : json['manifest_accounts_withdrawn_from_filter'],
        'manifest_accounts_deposited_into_filter': !exists(json, 'manifest_accounts_deposited_into_filter') ? undefined : json['manifest_accounts_deposited_into_filter'],
        'manifest_resources_filter': !exists(json, 'manifest_resources_filter') ? undefined : json['manifest_resources_filter'],
        'affected_global_entities_filter': !exists(json, 'affected_global_entities_filter') ? undefined : json['affected_global_entities_filter'],
        'events_filter': !exists(json, 'events_filter') ? undefined : ((json['events_filter'] as Array<any>).map(StreamTransactionsRequestEventFilterItemFromJSON)),
        'order': !exists(json, 'order') ? undefined : json['order'],
        'opt_ins': !exists(json, 'opt_ins') ? undefined : TransactionCommittedDetailsOptInsFromJSON(json['opt_ins']),
    };
}

export function StreamTransactionsRequestAllOfToJSON(value?: StreamTransactionsRequestAllOf | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'from_ledger_state': LedgerStateSelectorToJSON(value.from_ledger_state),
        'kind_filter': value.kind_filter,
        'manifest_accounts_withdrawn_from_filter': value.manifest_accounts_withdrawn_from_filter,
        'manifest_accounts_deposited_into_filter': value.manifest_accounts_deposited_into_filter,
        'manifest_resources_filter': value.manifest_resources_filter,
        'affected_global_entities_filter': value.affected_global_entities_filter,
        'events_filter': value.events_filter === undefined ? undefined : ((value.events_filter as Array<any>).map(StreamTransactionsRequestEventFilterItemToJSON)),
        'order': value.order,
        'opt_ins': TransactionCommittedDetailsOptInsToJSON(value.opt_ins),
    };
}


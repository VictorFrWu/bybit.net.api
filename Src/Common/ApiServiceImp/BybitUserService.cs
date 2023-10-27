using bybit.net.api.Models;
using bybit.net.api.Services;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.X86;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitUserService : BybitApiService
    {
        public BybitUserService(string apiKey, string apiSecret, bool useTestnet = true)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitUserService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = true)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        private const string PREUPGRADE_ORDER_HISTORY = "/v5/pre-upgrade/order/history";
        /// <summary>
        /// After the account is upgraded to a Unified account, you can get the orders which occurred before the upgrade.
        /// can get all status in 7 days
        /// can only get filled orders beyond 7 days
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="baseCoin"></param>
        /// <param name="orderId"></param>
        /// <param name="orderLinkId"></param>
        /// <param name="orderFilter"></param>
        /// <param name="orderStatus"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns>Get Pre-upgrade Order History</returns>
        public async Task<string?> GetPreUpgradeOrderHistory(Category category, string? symbol = null, string? baseCoin = null, string? orderId = null, string? orderLinkId = null, string? orderFilter = null,
                                                          OrderStatus? orderStatus = null, int? startTime = null, int? endTime = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "category", category.Value },
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("baseCoin", baseCoin),
                ("orderId", orderId),
                ("orderLinkId", orderLinkId),
                ("orderFilter", orderFilter),
                ("orderStatus", orderStatus?.Status),
                ("startTime", startTime),
                ("endTime", endTime),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(PREUPGRADE_ORDER_HISTORY, HttpMethod.Get, query: query);
            return result;
        }

        private const string PREUPGRADE_TRADE_HISTORY = "/v5/pre-upgrade/execution/list";
        /// <summary>
        /// Get users' execution records which occurred before you upgraded the account to a Unified account, sorted by execTime in descending order
        /// For now, it supports to query USDT perpetual, USDC perpetual, Inverse perpetual and futures, Option.
        /// Response items will have sorting issues When 'execTime' is the same.This issue is currently being optimized and will be released at the end of October. If you want to receive real-time execution information, Use the websocket stream (recommended).
        /// You may have multiple executions in a single order.
        /// You can query by symbol, baseCoin, orderId and orderLinkId, and if you pass multiple params, the system will process them according to this priority: orderId > orderLinkId > symbol > baseCoin.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="baseCoin"></param>
        /// <param name="orderId"></param>
        /// <param name="orderLinkId"></param>
        /// <param name="execType"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns>Get Pre-upgrade Trade History</returns>
        public async Task<string?> GetPreUpgradeTradeHistory(Category category, string? symbol = null, string? baseCoin = null, string? orderId = null, string? orderLinkId = null,
                                                          ExecType? execType = null, int? startTime = null, int? endTime = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "category", category.Value },
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("baseCoin", baseCoin),
                ("orderId", orderId),
                ("orderLinkId", orderLinkId),
                ("execType", execType?.Value),
                ("startTime", startTime),
                ("endTime", endTime),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(PREUPGRADE_TRADE_HISTORY, HttpMethod.Get, query: query);
            return result;
        }

        private const string PREUPGRADE_CLOSE_PNL = "/v5/pre-upgrade/position/closed-pnl";
        /// <summary>
        /// Query user's closed profit and loss records from before you upgraded the account to a Unified account. The results are sorted by createdTime in descending order.
        /// For now, it only supports to query USDT perpetual, Inverse perpetual and futures.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns>Get Pre-upgrade Closed PnL</returns>
        public async Task<string?> GetPreUpgradeClosePnl(Category category, string symbol, int? startTime = null, int? endTime = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "category", category.Value }, { "symbol", symbol}
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("startTime", startTime),
                ("endTime", endTime),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(PREUPGRADE_CLOSE_PNL, HttpMethod.Get, query: query);
            return result;
        }

        private const string PREUPGRADE_TRANSACTION_LOG = "/v5/pre-upgrade/position/closed-pnl";
        /// <summary>
        /// Query transaction logs which occurred in the USDC Derivatives wallet before the account was upgraded to a Unified account.
        /// You can get USDC Perpetual, Option records.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="baseCoin"></param>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns>Get Pre-upgrade Transaction Log</returns>
        public async Task<string?> GetPreUpgradeTransactionLog(Category category, string? baseCoin = null, TransactionType? type = null, int? startTime = null, int? endTime = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "category", category.Value },
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("baseCoin", baseCoin),
                ("type", type?.Value),
                ("startTime", startTime),
                ("endTime", endTime),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(PREUPGRADE_TRANSACTION_LOG, HttpMethod.Get, query: query);
            return result;
        }

        private const string PREUPGRADE_ASSET_DELIVERY = "/v5/pre-upgrade/asset/delivery-record";
        /// <summary>
        /// Query delivery records of Option before you upgraded the account to a Unified account, sorted by deliveryTime in descending order
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="expDate"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns>Get Pre-upgrade Option Delivery Record</returns>
        public async Task<string?> GetPreUpgradeAssetDeliveryRecord(Category category, string? symbol = null, string? expDate = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "category", category.Value },
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("expDate", expDate),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(PREUPGRADE_ASSET_DELIVERY, HttpMethod.Get, query: query);
            return result;
        }

        private const string PREUPGRADE_USDC_SETTLEMENT = "/v5/pre-upgrade/asset/settlement-record";
        public async Task<string?> GetPreUpgradeUsdcSettlement(Category category, string? symbol = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "category", category.Value },
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(PREUPGRADE_USDC_SETTLEMENT, HttpMethod.Get, query: query);
            return result;
        }

        private const string CREATE_SUB_USER = "/v5/user/create-sub-member";
        /// <summary>
        /// Create a new sub user id. Use master user's api key only.
        /// The API key must have one of the below permissions in order to call this endpoint..
        /// master API key: "Account Transfer", "Subaccount Transfer", "Withdrawal"
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="memberType"></param>
        /// <param name="switch"></param>
        /// <param name="isUta"></param>
        /// <param name="note"></param>
        /// <returns>new user member</returns>
        public async Task<string?> CreateSubMember(string username, MemberType memeberType, string? password = null, Switch? switchLogin = null, IsUta? isUta = null, string? note = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "username", username },
                            { "memeberType", memeberType.Value },
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("password", password),
                ("switch", switchLogin?.Value),
                ("isUta", isUta?.Value),
                ("note", note)
            );
            var result = await this.SendSignedAsync<string>(CREATE_SUB_USER, HttpMethod.Post, query: query);
            return result;
        }

    }
}

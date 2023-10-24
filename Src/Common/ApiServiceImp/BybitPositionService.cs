using bybit.net.api.Models;
using bybit.net.api.Services;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Buffers.Text;
using Microsoft.VisualBasic;
using System.Dynamic;
using System.Reflection;
using System.Threading.Channels;
using System.Collections;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.X86;


namespace bybit.net.api.ApiServiceImp
{
    public class BybitPositionService : BybitApiService
    {
        public BybitPositionService(string apiKey, string apiSecret, bool useTestnet = true)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitPositionService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = true)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        private const string POSITION_LIST = "/v5/position/list";
        /// <summary>
        /// Query real-time position data, such as position size, cumulative realizedPNL.
        /// Unified account covers: USDT perpetual / USDC contract / Inverse contract / Options
        /// Classic account covers: USDT perpetual / Inverse contract
        /// Regarding inverse contracts,
        /// you can query all holding positions with "/v5/position/list?category=inverse";
        /// symbol parameter is supported to be passed with multiple symbols up to 10
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="baseCoin"></param>
        /// <param name="settleCoin"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns>Position Info</returns>
        public async Task<string?> GetPositionInfo(Category category, string? symbol = null, string? baseCoin = null, string? settleCoin = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object> { { "category", category.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("baseCoin", baseCoin),
                ("settleCoin", settleCoin),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(POSITION_LIST, HttpMethod.Get, query: query);
            return result;
        }

        private const string SET_LEVERAGE = "/v5/position/set-leverage";
        /// <summary>
        /// Set the leverage
        /// Unified account covers: USDT perpetual / USDC contract / Inverse contract
        /// Classic account covers: USDT perpetual / Inverse contract
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="buyLeverage"></param>
        /// <param name="sellLeverage"></param>
        /// <returns>None</returns>
        public async Task<string?> SetPositionLeverage(Category category, string symbol, string buyLeverage, string sellLeverage)
        {
            var query = new Dictionary<string, object> { { "category", category.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("buyLeverage", buyLeverage),
                ("sellLeverage", sellLeverage)
            );
            var result = await this.SendSignedAsync<string>(SET_LEVERAGE, HttpMethod.Post, query: query);
            return result;
        }

        private const string SWITCH_MARGIN = "/v5/position/switch-isolated";
        /// <summary>
        /// Switch Cross/Isolated Margin Select cross margin mode or isolated margin mode per symbol level
        /// Unified account covers: Inverse contract
        /// Classic account covers: USDT perpetual / Inverse contract
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="tradeMode"></param>
        /// <param name="buyLeverage"></param>
        /// <param name="sellLeverage"></param>
        /// <returns>None</returns>
        public async Task<string?> SwitchPositionMargin(Category category, string symbol, TradeMode tradeMode, string buyLeverage, string sellLeverage)
        {
            var query = new Dictionary<string, object> { { "category", category.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("buyLeverage", buyLeverage),
                ("sellLeverage", sellLeverage),
                ("tradeMode", tradeMode.Value)
            );
            var result = await this.SendSignedAsync<string>(SWITCH_MARGIN, HttpMethod.Post, query: query);
            return result;
        }

        private const string SET_TPSL_MODE = "/v5/position/set-tpsl-mode";
        /// <summary>
        /// To some extent, this endpoint is depreciated because now tpsl is based on order level. This API was used for position level change before.
        /// However, you still can use it to set an implicit tpsl mode for a certain symbol because when you don't pass "tpslMode" in the place order or trading stop request, system will get the tpslMode by the default setting.
        /// Set TP/SL mode to Full or Partial
        /// Unified account covers: USDT perpetual / Inverse contract
        /// Classic account covers: USDT perpetual / Inverse contract
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="tpslMode"></param>
        /// <returns>tpSlMode </returns>
        public async Task<string?> SetTPSLMode(Category category, string symbol, TpslMode tpslMode)
        {
            var query = new Dictionary<string, object> { { "category", category.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("tpslMode", tpslMode.Value)
            );
            var result = await this.SendSignedAsync<string>(SET_TPSL_MODE, HttpMethod.Post, query: query);
            return result;
        }

        private const string SWITCH_POSITION_MODE = "/v5/position/switch-mode";
        /// <summary>
        /// It supports to switch the position mode for USDT perpetual and Inverse futures. If you are in one-way Mode, you can only open one position on Buy or Sell side. If you are in hedge mode, you can open both Buy and Sell side positions simultaneously.
        /// Unified account covers: USDT perpetual / Inverse Futures
        ///Classic account covers: USDT perpetual / Inverse Futures
        /// Priority for configuration to take effect: symbol > coin > system default
        /// System default: one-way mode
        /// If the request is by coin(settleCoin), then all symbols based on this setteCoin that do not have position and open order will be batch switched, and new listed symbol based on this settleCoin will be the same mode you set.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="coin"></param>
        /// <param name="positionMode"></param>
        /// <returns>None</returns>
        public async Task<string?> SwitchPositionMode(Category category, string? symbol = null, string? coin = null, PositionMode? positionMode = null)
        {
            var query = new Dictionary<string, object> { { "category", category.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                 ("coin", coin),
                ("positionMode", positionMode?.Value)
            );
            var result = await this.SendSignedAsync<string>(SWITCH_POSITION_MODE, HttpMethod.Post, query: query);
            return result;
        }

        private const string SET_RISK_LIMIT = "/v5/position/set-risk-limit";
        /// <summary>
        /// The risk limit will limit the maximum position value you can hold under different margin requirements. If you want to hold a bigger position size, you need more margin. This interface can set the risk limit of a single position. If the order exceeds the current risk limit when placing an order, it will be rejected. Click here to learn more about risk limit.
        /// Unified account covers: USDT perpetual / USDC contract / Inverse contract
        /// Classic account covers: USDT perpetual / Inverse contract
        /// Set the risk limit of the position.You can get risk limit information for each symbol here.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="riskId"></param>
        /// <param name="positionIdx"></param>
        /// <returns>Risk Limit Info</returns>
        public async Task<string?> SetPositionRiskLimit(Category category, string symbol, int riskId, PositionIndex? positionIdx = null)
        {
            var query = new Dictionary<string, object> { { "category", category.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                 ("coin", riskId),
                ("positionIdx", positionIdx?.Value)
            );
            var result = await this.SendSignedAsync<string>(SET_RISK_LIMIT, HttpMethod.Post, query: query);
            return result;
        }

        private const string SET_TRADING_STOP = "/v5/position/trading-stop";
        /// <summary>
        /// Set the take profit, stop loss or trailing stop for the position.
        /// Unified account covers: USDT perpetual / USDC contract / Inverse contract
        /// Classic account covers: USDT perpetual / Inverse contract
        /// New version of TP/SL function supports both holding entire position TP/SL orders and holding partial position TP/SL orders.
        /// Full position TP/SL orders: This API can be used to modify the parameters of existing TP/SL orders.
        /// Partial position TP/SL orders: This API can only add partial position TP/SL orders.
        /// Under the new version of Tp/SL function, when calling this API to perform one-sided take profit or stop loss modification on existing TP/SL orders on the holding position, it will cause the paired tp/sl orders to lose binding relationship. This means that when calling the cancel API through the tp/sl order ID, it will only cancel the corresponding one-sided take profit or stop loss order ID.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="positionIndex"></param>
        /// <param name="takeProfit"></param>
        /// <param name="stopLoss"></param>
        /// <param name="tpTriggerBy"></param>
        /// <param name="slTriggerBy"></param>
        /// <param name="trailingStop"></param>
        /// <param name="tpslMode"></param>
        /// <param name="tpSize"></param>
        /// <param name="slSize"></param>
        /// <param name="tpLimitPrice"></param>
        /// <param name="slLimitPrice"></param>
        /// <param name="tpOrderType"></param>
        /// <param name="slOrderType"></param>
        /// <returns>None</returns>
        public async Task<string?> SetPositionTradingStop(Category category, string symbol, PositionIndex positionIndex, string? takeProfit = null,
        string? stopLoss = null, TriggerBy? tpTriggerBy = null, TriggerBy? slTriggerBy = null, string? trailingStop = null, TpslMode? tpslMode = null,
                                                string? tpSize = null, string? slSize = null, string? tpLimitPrice = null, string? slLimitPrice = null, OrderType? tpOrderType = null, OrderType? slOrderType = null)
        {
            var query = new Dictionary<string, object> { { "category", category.Value }, { "symbol", symbol }, { "positionIndex", positionIndex.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("takeProfit", takeProfit),
                ("stopLoss", stopLoss),
                ("tpTriggerBy", tpTriggerBy?.Value),
                ("slTriggerBy", slTriggerBy?.Value),
                ("trailingStop", trailingStop),
                ("tpslMode", tpslMode?.Value),
                 ("tpSize", tpSize),
                ("slSize", slSize),
                ("tpLimitPrice", tpLimitPrice),
                ("slLimitPrice", slLimitPrice),
                ("tpOrderType", tpOrderType?.Value),
                ("slOrderType", slOrderType?.Value)
            );
            var result = await this.SendSignedAsync<string>(SET_TRADING_STOP, HttpMethod.Post, query: query);
            return result;
        }

        private const string SET_AUTO_ADD_MARGIN = "/v5/position/set-auto-add-margin";
        /// <summary>
        /// Turn on/off auto-add-margin for isolated margin position
        /// Unified account covers: USDT perpetual / USDC perpetual / USDC futures / Inverse contract
        /// Classic account covers: USDT perpetual / Inverse contract
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="autoAddMargin"></param>
        /// <param name="positionIdx"></param>
        /// <returns>None</returns>
        public async Task<string?> SetPositionAutoAddMargin(Category category, string symbol, AutoAddMargin autoAddMargin, PositionIndex positionIdx)
        {
            var query = new Dictionary<string, object> { { "category", category.Value }, { "symbol", symbol }, { "autoAddMargin", autoAddMargin.Value }, { "positionIdx", positionIdx.Value } };

            var result = await this.SendSignedAsync<string>(SET_AUTO_ADD_MARGIN, HttpMethod.Post, query: query);
            return result;
        }

        private const string UPDATE_MARGIN = "/v5/position/add-margin";
        /// <summary>
        /// Manually add or reduce margin for isolated margin position
        /// Unified account covers: USDT perpetual / USDC perpetual / USDC futures / Inverse contract
        /// Classic account covers: USDT perpetual / Inverse contract
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="margin"></param>
        /// <param name="positionIdx"></param>
        /// <returns>Position Margin</returns>
        public async Task<string?> SetPositionUpdateMargin(Category category, string symbol, string margin, PositionIndex? positionIdx = null)
        {
            var query = new Dictionary<string, object> { { "category", category.Value }, { "symbol", symbol }, { "margin", margin }, };
            BybitParametersUtils.AddOptionalParameters(query,
               ("positionIdx", positionIdx?.Value));
            var result = await this.SendSignedAsync<string>(UPDATE_MARGIN, HttpMethod.Post, query: query);
            return result;
        }

        private const string EXECUTION_LIST = "/v5/execution/list";
        /// <summary>
        /// Get Execution
        /// Query users' execution records, sorted by execTime in descending order. However, for Classic spot, they are sorted by execId in descending order.
        /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
        /// Classic account covers: Spot / USDT perpetual / Inverse contract
        /// Response items will have sorting issues When 'execTime' is the same.This issue is currently being optimized and will be released at the end of October. If you want to receive real-time execution information, Use the websocket stream (recommended).
        /// You may have multiple executions in a single order.
        /// You can query by symbol, baseCoin, orderId and orderLinkId, and if you pass multiple params, the system will process them according to this priority: orderId > orderLinkId > symbol > baseCoin.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="orderLinkId"></param>
        /// <param name="baseCoin"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="execType"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns> Execution List </returns>
        public async Task<string?> GetExecutionList(Category category, string? symbol = null, string? orderId = null, string? orderLinkId = null, string? baseCoin = null, int? startTime = null, int? endTime = null, ExecType? execType = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object> { { "category", category.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("orderId", orderId),
                ("orderLinkId", orderLinkId),
                ("baseCoin", baseCoin),
                ("startTime", startTime),
                 ("endTime", endTime),
                 ("execType", execType?.Value),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(EXECUTION_LIST, HttpMethod.Get, query: query);
            return result;
        }

        private const string CLOSE_PNL = "/v5/position/closed-pnl";
        public async Task<string?> GetClosedPnl(Category category, string? symbol = null, int? startTime = null, int? endTime = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object> { { "category", category.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("symbol", symbol),
                ("startTime", startTime),
                 ("endTime", endTime),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(CLOSE_PNL, HttpMethod.Get, query: query);
            return result;
        }
    }
}

using bybit.net.api.Models;
using bybit.net.api.Services;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitTradeService : BybitApiService
    {
        public BybitTradeService(string apiKey, string apiSecret, bool useTestnet = true)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitTradeService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = true)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        private const string NEW_ORDER = "/v5/order/create";
        /// <summary>
        /// Send in a new order.
        /// - Supported order types: Limit order (specify order qty and price), Market order (execute at best available market price, with price conversion protections).
        /// - Supported timeInForce strategies: GTC, IOC, FOK, PostOnly (higher quantity limits, consult instruments-info endpoint).
        /// - Conditional orders: Converted when triggerPrice is set; does not occupy margin, may be canceled if margin is insufficient post-trigger.
        /// - Take Profit/Stop Loss: Can be set during order placement and modified for positions.
        /// - Order quantity for perpetual contracts must be positive.
        /// - Limit order price: Must be above liquidation price, consult instruments-info endpoint for minimum changes.
        /// - Custom order IDs (orderLinkId) can be used for linking to system IDs; prioritize orderId over orderLinkId if both provided.
        /// - Order limits: Futures (500 active orders per contract), Spot (500 total, 30 TP/SL, 30 conditional), Option (100 open).
        /// - Rate limits and risk control limits apply. Excessive API requests may trigger restrictions.
        /// TIP: Borrow margin for margin trading on spot in a normal account.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="side"></param>
        /// <param name="orderType"></param>
        /// <param name="qty"></param>
        /// <param name="price"></param>
        /// <param name="timeInForce"></param>
        /// <param name="isLeverage"></param>
        /// <param name="triggerDirection"></param>
        /// <param name="orderFilter"></param>
        /// <param name="triggerPrice"></param>
        /// <param name="triggerBy"></param>
        /// <param name="orderIv"></param>
        /// <param name="positionIdx"></param>
        /// <param name="orderLinkId"></param>
        /// <param name="takeProfit"></param>
        /// <param name="stopLoss"></param>
        /// <param name="tpTriggerBy"></param>
        /// <param name="slTriggerBy"></param>
        /// <param name="reduceOnly"></param>
        /// <param name="closeOnTrigger"></param>
        /// <param name="smpType"></param>
        /// <param name="mmp"></param>
        /// <param name="tpslMode"></param>
        /// <param name="tpLimitPrice"></param>
        /// <param name="slLimitPrice"></param>
        /// <param name="tpOrderType"></param>
        /// <param name="slOrderType"></param>
        /// <returns>Order result</returns>
        public async Task<string?> PlaceOrder(Category category, string symbol, Side side, OrderType orderType, string qty, string? price = null, TimeInForce? timeInForce = null, int? isLeverage = null, int? triggerDirection = null,
                                                string? orderFilter = null, string? triggerPrice = null, TriggerBy? triggerBy = null, string? orderIv = null, int? positionIdx = null,string? orderLinkId = null, string? takeProfit = null,
                                                string? stopLoss = null, TriggerBy? tpTriggerBy = null, TriggerBy? slTriggerBy = null, bool? reduceOnly = null, bool? closeOnTrigger = null,SmpType? smpType = null,bool? mmp = null,TpslMode? tpslMode = null,
                                                string? tpLimitPrice = null,string? slLimitPrice = null,string? tpOrderType = null, string? slOrderType = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "category", category.Value },
                            { "symbol", symbol },
                            { "side", side.Value },
                            { "orderType", orderType.Value },
                            { "qty", qty }
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("price", price),
                ("timeInForce", timeInForce?.Value),
                ("isLeverage", isLeverage),
                ("triggerDirection", triggerDirection),
                ("orderFilter", orderFilter),
                ("triggerPrice", triggerPrice),
                ("triggerBy", triggerBy?.Value),
                ("orderIv", orderIv),
                ("positionIdx", positionIdx),
                ("orderLinkId", orderLinkId),
                ("takeProfit", takeProfit),
                ("stopLoss", stopLoss),
                ("tpTriggerBy", tpTriggerBy?.Value),
                ("slTriggerBy", slTriggerBy?.Value),
                ("reduceOnly", reduceOnly),
                ("closeOnTrigger", closeOnTrigger),
                ("smpType", smpType?.Value),
                ("mmp", mmp),
                ("tpslMode", tpslMode?.Value),
                ("tpLimitPrice", tpLimitPrice),
                ("slLimitPrice", slLimitPrice),
                ("tpOrderType", tpOrderType),
                ("slOrderType", slOrderType)
            );
            var result = await this.SendSignedAsync<string>(NEW_ORDER, HttpMethod.Post, query: query);
            return result;
        }
    }
}

using bybit.net.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.ApiServiceImp
{
    internal class BybitEarnService : BybitApiService
    {
        public BybitEarnService(string apiKey, string apiSecret, string? url = null, string recvWindow = BybitConstants.DEFAULT_REC_WINDOW, bool debugMode = false)
        : this(httpClient: new HttpClient(), apiKey: apiKey, apiSecret: apiSecret, url: url, recvWindow: recvWindow, debugMode: debugMode)
        {
        }

        public BybitEarnService(HttpClient httpClient, string apiKey, string apiSecret, string? url = null, string recvWindow = BybitConstants.DEFAULT_REC_WINDOW, bool debugMode = false)
            : base(httpClient: httpClient, apiKey: apiKey, apiSecret: apiSecret, url: url, recvWindow: recvWindow, debugMode: debugMode)
        {
        }

        private const string GET_PRODUCT_INFO = "/v5/earn/product";

        /// <summary>
        /// Get Product Info
        /// Public. Returns Earn product specs for FlexibleSaving or OnChain.
        /// </summary>
        /// <param name="category">FlexibleSaving or OnChain</param>
        /// <param name="coin">Optional coin</param>
        /// <returns></returns>
        public async Task<string?> GetProductInfo(string category, string? coin = null)
        {
            var query = new Dictionary<string, object> { { "category", category } };
            BybitParametersUtils.AddOptionalParameters(query, ("coin", coin));

            var result = await this.SendPublicAsync<string>(GET_PRODUCT_INFO, HttpMethod.Get, query: query);
            return result;
        }

        private const string PLACE_EARN_ORDER = "/v5/earn/place-order";

        /// <summary>
        /// Stake / Redeem
        /// Place Earn order for FlexibleSaving or OnChain. API key needs "Earn" permission.
        /// </summary>
        /// <param name="category">FlexibleSaving or OnChain</param>
        /// <param name="orderType">Stake or Redeem</param>
        /// <param name="accountType">FUND or UNIFIED (OnChain supports FUND only)</param>
        /// <param name="amount">Amount; must meet product precision/limits</param>
        /// <param name="coin">Coin name</param>
        /// <param name="productId">Product ID</param>
        /// <param name="orderLinkId">Custom ID, up to 36 chars</param>
        /// <param name="redeemPositionId">Required for OnChain non-LST redeem</param>
        /// <param name="toAccountType">
        /// FUND or UNIFIED. OnChain LST: FUND/UNIFIED (custodial subaccount UNIFIED only). OnChain non-LST: FUND only.
        /// </param>
        /// <returns></returns>
        public async Task<string?> PlaceEarnOrder(
            string category,
            string orderType,
            string accountType,
            string amount,
            string coin,
            string productId,
            string orderLinkId,
            string? redeemPositionId = null,
            string? toAccountType = null)
        {
            var body = new Dictionary<string, object>
            {
                { "category", category },
                { "orderType", orderType },
                { "accountType", accountType },
                { "amount", amount },
                { "coin", coin },
                { "productId", productId },
                { "orderLinkId", orderLinkId }
            };

            BybitParametersUtils.AddOptionalParameters(body,
                ("redeemPositionId", redeemPositionId),
                ("toAccountType", toAccountType)
            );

            var result = await this.SendSignedAsync<string>(PLACE_EARN_ORDER, HttpMethod.Post, query: body);
            return result;
        }

        private const string GET_EARN_ORDER_HISTORY = "/v5/earn/order";

        /// <summary>
        /// Get Stake/Redeem Order History
        /// Earn permission required. For FlexibleSaving or OnChain.
        /// </summary>
        /// <param name="category">FlexibleSaving or OnChain</param>
        /// <param name="orderId">Order ID (required if orderLinkId is null)</param>
        /// <param name="orderLinkId">
        /// Order link ID (required if orderId is null). If reused, returns the latest.
        /// </param>
        /// <returns></returns>
        public async Task<string?> GetEarnOrderHistory(string category, string? orderId = null, string? orderLinkId = null)
        {
            var query = new Dictionary<string, object> { { "category", category } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("orderId", orderId),
                ("orderLinkId", orderLinkId)
            );

            var result = await this.SendSignedAsync<string>(GET_EARN_ORDER_HISTORY, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_STAKED_POSITION = "/v5/earn/position";

        /// <summary>
        /// Get Staked Position
        /// Earn permission required. FlexibleSaving returns active and fully redeemed positions.
        /// OnChain returns active positions only.
        /// </summary>
        /// <param name="category">FlexibleSaving or OnChain</param>
        /// <param name="productId">Optional product ID</param>
        /// <param name="coin">Optional coin</param>
        /// <returns></returns>
        public async Task<string?> GetStakedPosition(string category, string? productId = null, string? coin = null)
        {
            var query = new Dictionary<string, object> { { "category", category } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("productId", productId),
                ("coin", coin)
            );

            var result = await this.SendSignedAsync<string>(GET_STAKED_POSITION, HttpMethod.Get, query: query);
            return result;
        }

    }
}

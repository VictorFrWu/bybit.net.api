using bybit.net.api.Models;
using bybit.net.api.Services;
using System.Net.Sockets;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitLendingService : BybitApiService
    {
        public BybitLendingService(string apiKey, string apiSecret, bool useTestnet = false)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitLendingService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = false)
            : base(httpClient: httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        #region Instituion Lending
        private const string INS_PRODUCT_INFO = "/v5/ins-loan/product-infos";
        /// <summary>
        /// This endpoint can be queried without api key and secret, then it returns public product data
        /// If your uid is bound with OTC loan product, then you can get your private product data by calling the endpoint with api key and secret
        /// If your uid is not bound with OTC loan product but api key and secret are also passed, it will return public data only
        /// </summary>
        /// <param name="productId"></param>
        /// <returns> Get Product Info </returns>
        public async Task<string?> GetInsLoanInfo(string? productId = null)
        {
            var query = new Dictionary<string, object> { };

            BybitParametersUtils.AddOptionalParameters(query,
                ("productId", productId)
            );
            var result = await this.SendSignedAsync<string>(INS_PRODUCT_INFO, HttpMethod.Get, query: query);
            return result;
        }

        private const string INS_MARGIN_COIN = "/v5/ins-loan/ensure-tokens-convert";
        /// <summary>
        /// This endpoint can be queried without api key and secret, then it returns public margin data
        /// If your uid is bound with OTC loan product, then you can get your private margin data by calling the endpoint with api key and secret
        /// If your uid is not bound with OTC loan product but api key and secret are also passed, it will return public data only
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Get Margin Coin Info</returns>
        public async Task<string?> GetInsMarginCoinInfo(string? productId = null)
        {
            var query = new Dictionary<string, object> { };

            BybitParametersUtils.AddOptionalParameters(query,
                ("productId", productId)
            );
            var result = await this.SendSignedAsync<string>(INS_MARGIN_COIN, HttpMethod.Get, query: query);
            return result;
        }

        private const string INS_LOAN_ORDERS = "/v5/ins-loan/ensure-tokens-convert";
        /// <summary>
        /// Get the past 2 years data by default
        /// Get up to the past 2 years of data
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit"></param>
        /// <returns>Get Loan Orders</returns>
        public async Task<string?> GetInsLoanOrders(string? orderId = null, int? startTime = null, int? endTime = null, int? limit = null)
        {
            var query = new Dictionary<string, object> { };

            BybitParametersUtils.AddOptionalParameters(query,
                ("orderId", orderId),
                ("startTime", startTime),
                ("endTime", endTime),
                ("limit", limit)
            );
            var result = await this.SendSignedAsync<string>(INS_LOAN_ORDERS, HttpMethod.Get, query: query);
            return result;
        }

        private const string INS_LOAN_REPAY_ORDERS = "/v5/ins-loan/ensure-tokens-convert";
        /// <summary>
        /// Get the past 2 years data by default
        /// Get up to the past 2 years of data
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit"></param>
        /// <returns>Get Repay Orders</returns>
        public async Task<string?> GetInsLoanRepayOrders(int? startTime = null, int? endTime = null, int? limit = null)
        {
            var query = new Dictionary<string, object> { };

            BybitParametersUtils.AddOptionalParameters(query,
                ("startTime", startTime),
                ("endTime", endTime),
                ("limit", limit)
            );
            var result = await this.SendSignedAsync<string>(INS_LOAN_REPAY_ORDERS, HttpMethod.Get, query: query);
            return result;
        }

        private const string INS_LOAN_TO_VALUE = "/v5/ins-loan/ltv-convert";
        /// <summary>
        /// Get LTV
        /// </summary>
        /// <returns> Loan To Value</returns>
        public async Task<string?> GetInsLoanToValue()
        {
            var query = new Dictionary<string, object> { };
            var result = await this.SendSignedAsync<string>(INS_LOAN_TO_VALUE, HttpMethod.Get, query: query);
            return result;
        }
        #endregion

        #region C2C Lending
        #endregion
    }
}
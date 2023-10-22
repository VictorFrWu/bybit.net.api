using bybit.net.api.Models;
using bybit.net.api.Services;
using System.Net;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitAssetService : BybitApiService
    {
        public BybitAssetService(string apiKey, string apiSecret, bool useTestnet = true)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitAssetService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = true)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        private const string COIN_EXCHANGE_RECORDS = "/v5/asset/exchange/order-record";
        /// <summary>
        ///  Query the coin exchange records.
        /// This endpoint currently is not available to get data after 12 Mar 2023. We will make it fully available later.
        /// CAUTION : You may have a long delay of this endpoint.
        /// </summary>
        /// <param name="fromCoin"></param>
        /// <param name="toCoin"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns>Coin Exchange Records</returns>
        public async Task<string?> GetCoinExchangeRecords(string? fromCoin = null, string? toCoin = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("fromCoin", fromCoin),
                ("toCoin", toCoin),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(COIN_EXCHANGE_RECORDS, HttpMethod.Get, query: query);
            return result;
        }
    }
}

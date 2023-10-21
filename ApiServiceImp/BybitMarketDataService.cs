using bybit.net.api.Services;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitMarketDataService : BybitApiService
    {
        public BybitMarketDataService(bool useTestnet = true, string? apiKey = null, string? apiSecret = null)
        : this(new HttpClient(), useTestnet, apiKey, apiSecret)
        {
        }

        public BybitMarketDataService(HttpClient httpClient, bool useTestnet = true, string ? apiKey = null, string? apiSecret = null)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        private const string CHECK_SERVER_TIME = "/v5/market/time";

        /// <summary>
        /// Get Bybit Server Time.<para />
        /// </summary>
        /// <returns>Bybit server UTC timestamp.</returns>
        public async Task<string?> CheckServerTime()
        {
            var result = await SendPublicAsync<string>(
                CHECK_SERVER_TIME,
                HttpMethod.Get);

            return result;
        }

        private const string MAKRKET_KLINE = "/v5/market/kline";

        /// <summary>
        /// Query for historical mark price klines. Charts are returned in groups based on the requested interval.
        /// Covers: USDT perpetual / USDC contract / Inverse contract
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="limit"></param>
        /// <returns>Market kline</returns>
        public async Task<string?> GetMarketKline(string category, string symbol, string interval, int? start = null, int? end = null, int? limit = null)
        {
            var query = new Dictionary<string, object>
                        {
                    { "category", category },
                    { "symbol", symbol },
                    { "interval", interval }, };
            if (start.HasValue) query.Add("start", start.Value);
            if (end.HasValue) query.Add("end", end.Value);
            if (limit.HasValue) query.Add("limit", limit);
            var result = await SendPublicAsync<string>(
                MAKRKET_KLINE,
                HttpMethod.Get,
                query: query);

            return result;
        }

        private const string MAKR_PRICE_KLINE = "/v5/market/mark-price-kline";
        /// <summary>
        /// Query for historical mark price klines. Charts are returned in groups based on the requested interval.
        /// Covers: USDT perpetual / USDC contract / Inverse contract
        /// </summary>
        /// <param name="category"></param>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="limit"></param>
        /// <returns>Market kline</returns>
        public async Task<string?> GetMarKPricetKline(string category, string symbol, string interval, int? start = null, int? end = null, int? limit = null)
        {
            var query = new Dictionary<string, object>
                        {
                    { "category", category },
                    { "symbol", symbol },
                    { "interval", interval }, };
            if (start.HasValue) query.Add("start", start.Value);
            if (end.HasValue) query.Add("end", end.Value);
            if (limit.HasValue) query.Add("limit", limit);

            var result = await SendPublicAsync<string>(
                MAKR_PRICE_KLINE,
                HttpMethod.Get,
                query: query
                );

            return result;
        }
    }
}

using bybit.net.api.Services;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitMarketDataService : BybitApiService
    {
        public BybitMarketDataService(string? apiKey = null, string? apiSecret = null, bool? useTestnet = null)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitMarketDataService(HttpClient httpClient, string? apiKey = null, string? apiSecret = null, bool? useTestnet = null)
            : base(httpClient, apiKey, apiSecret, useTestnet)
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
        /// <returns></returns>
        public async Task<string?> GetMarketKline(string category, string symbol, string interval, int? start = null, int? end = null, int? limit = null)
        {
            var result = await SendPublicAsync<string>(
                MAKRKET_KLINE,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "category", category },
                    { "symbol", symbol },
                    { "interval", interval },
                    { "start", start },
                    { "end", end },
                    { "limit", limit },
                });

            return result;
        }
    }
}

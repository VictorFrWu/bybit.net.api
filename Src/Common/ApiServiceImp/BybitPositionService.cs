using bybit.net.api.Models;
using bybit.net.api.Services;


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
        public async Task<string?> GetPositionInfo(Category category, string? symbol = null, string? baseCoin = null, string? settleCoin = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>{{ "category", category.Value }};

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
    }
}

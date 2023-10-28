namespace bybit.net.api.Services
{
    public abstract class BybitApiService : BybitService
    {
        public BybitApiService(HttpClient httpClient, bool useTestnet = false, string ? apiKey = null, string? apiSecret = null) 
            : base(httpClient: httpClient, useTestnet: useTestnet, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public BybitApiService(HttpClient httpClient, bool useTestnet = false)
            : base(httpClient: httpClient, useTestnet: useTestnet)
        {
        }
    }
}

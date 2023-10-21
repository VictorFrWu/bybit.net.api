namespace bybit.net.api.Services
{
    public abstract class BybitApiService : BybitService
    {
        public BybitApiService(HttpClient httpClient, bool useTestnet = true, string ? apiKey = null, string? apiSecret = null) 
            : base(httpClient: httpClient, useTestnet: useTestnet, apiKey: apiKey, apiSecret: apiSecret)
        {
        }
    }
}

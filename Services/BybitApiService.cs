namespace bybit.net.api.Services
{
    public abstract class BybitApiService : BybitService
    {
        public BybitApiService(HttpClient httpClient, string? apiKey = null, string? apiSecret = null, bool? useTestnet = null) 
            : base(httpClient: httpClient, apiKey: apiKey, apiSecret: apiSecret, useTestnet: useTestnet)
        {
        }
    }
}

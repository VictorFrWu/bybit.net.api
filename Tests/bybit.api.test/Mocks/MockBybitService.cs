using bybit.net.api;

namespace bybit.api.test.Mocks
{
    public class MockBybitService : BybitService
    {
        public MockBybitService(HttpClient httpClient, string? apiKey = null, string? apiSecret = null, bool? useTestnet = null)
        : base(httpClient:httpClient, apiKey: apiKey, apiSecret: apiSecret, useTestnet: useTestnet)
        {
        }

        public new async Task<T?> SendPublicAsync<T>(string requestUri, HttpMethod httpMethod, Dictionary<string, object>? query = null)
        {
            return await base.SendPublicAsync<T>(requestUri, httpMethod, query: query);
        }

        public new async Task<T?> SendSignedAsync<T>(string requestUri, HttpMethod httpMethod, Dictionary<string, object>? query = null)
        {
            return await base.SendSignedAsync<T>(requestUri, httpMethod, query: query);
        }
    }
}

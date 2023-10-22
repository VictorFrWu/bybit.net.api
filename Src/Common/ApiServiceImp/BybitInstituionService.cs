using bybit.net.api.Services;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitInstituionService : BybitApiService
    {
        public BybitInstituionService(string apiKey, string apiSecret, bool useTestnet = true)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitInstituionService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = true)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }
    }
}
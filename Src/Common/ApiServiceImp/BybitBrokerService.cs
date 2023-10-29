using bybit.net.api.Models.Lending;
using bybit.net.api.Services;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitBrokerService : BybitApiService
    {
        public BybitBrokerService(string apiKey, string apiSecret, bool useTestnet = false)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitBrokerService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = false)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        private const string BROKER_EARNING_DATA = "/v5/broker/earning-record";
       
        public async Task<string?> GetBrokerEarning(BizType? bizType = null, int? startTime = null, int? endTime = null, int? limit = null, string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("bizType", bizType?.Value),
                ("startTime", startTime),
                ("endTime", endTime),
                ("limit", limit),
                ("cursor", cursor)
            );
            var result = await this.SendSignedAsync<string>(BROKER_EARNING_DATA, HttpMethod.Get, query: query);
            return result;
        }
    }
}

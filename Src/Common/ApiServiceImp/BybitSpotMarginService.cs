using bybit.net.api.Models;
using bybit.net.api.Services;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitSpotMarginService : BybitApiService
    {
        public BybitSpotMarginService(string apiKey, string apiSecret, bool useTestnet = true)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitSpotMarginService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = true)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }
        private const string SPOT_MARGIN_DATA = "/v5/spot-margin-trade/data";
        /// <summary>
        /// This margin data is for Unified account in particular.
        /// </summary>
        /// <param name="vipLevel"></param>
        /// <param name="currency"></param>
        /// <returns>spot margin data</returns>
        public async Task<string?> GetAccountBalance(VipLevel? vipLevel = null, string? currency = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("vipLevel", vipLevel?.Value),
                ("currency", currency)
            );
            var result = await this.SendPublicAsync<string>(SPOT_MARGIN_DATA, HttpMethod.Get, query: query);
            return result;
        }
    }
}
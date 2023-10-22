using bybit.net.api.Models;
using bybit.net.api.Services;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitAccountService : BybitApiService
    {
        public BybitAccountService(string apiKey, string apiSecret, bool useTestnet = true)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitAccountService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = true)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        private const string WALLET_BALANCE = "/v5/account/wallet-balance";
        public async Task<string?> GetAccountBalance(AccountType accountType, string? coin = null)
        {
            var query = new Dictionary<string, object> { { "accountType", accountType.Value } };

            BybitParametersUtils.AddOptionalParameters(query,
                ("coin", coin)
            );
            var result = await this.SendSignedAsync<string>(WALLET_BALANCE, HttpMethod.Get, query: query);
            return result;
        }
    }
}

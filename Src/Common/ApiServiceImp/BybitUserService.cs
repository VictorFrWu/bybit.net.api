using bybit.net.api.Models;
using bybit.net.api.Services;
using System.Diagnostics.Metrics;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitUserService : BybitApiService
    {
        public BybitUserService(string apiKey, string apiSecret, bool useTestnet = true)
        : this(new HttpClient(), apiKey, apiSecret, useTestnet)
        {
        }

        public BybitUserService(HttpClient httpClient, string apiKey, string apiSecret, bool useTestnet = true)
            : base(httpClient, useTestnet, apiKey, apiSecret)
        {
        }

        private const string CREATE_SUB_USER = "/v5/user/create-sub-member";
        /// <summary>
        /// Create a new sub user id. Use master user's api key only.
        /// The API key must have one of the below permissions in order to call this endpoint..
        /// master API key: "Account Transfer", "Subaccount Transfer", "Withdrawal"
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="memberType"></param>
        /// <param name="switch"></param>
        /// <param name="isUta"></param>
        /// <param name="note"></param>
        /// <returns>new user member</returns>
        public async Task<string?> CreateSubMember(string username, MemberType memeberType, string? password = null, Switch? switchLogin =null, IsUta? isUta = null, string? note = null)
        {
            var query = new Dictionary<string, object>
                        {
                            { "username", username },
                            { "memeberType", memeberType.Value },
                        };

            BybitParametersUtils.AddOptionalParameters(query,
                ("password", password),
                ("switch", switchLogin?.Value),
                ("isUta", isUta?.Value),
                ("note", note)
            );
            var result = await this.SendSignedAsync<string>(CREATE_SUB_USER, HttpMethod.Post, query: query);
            return result;
        }
    }
}

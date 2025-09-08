using bybit.net.api.Models.Lending;
using bybit.net.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitAffiliateService : BybitApiService
    {
        public BybitAffiliateService(string apiKey, string apiSecret, string? url = null, string recvWindow = BybitConstants.DEFAULT_REC_WINDOW, bool debugMode = false)
        : this(httpClient: new HttpClient(), apiKey: apiKey, apiSecret: apiSecret, url: url, recvWindow: recvWindow, debugMode: debugMode)
        {
        }

        public BybitAffiliateService(HttpClient httpClient, string apiKey, string apiSecret, string? url = null, string recvWindow = BybitConstants.DEFAULT_REC_WINDOW, bool debugMode = false)
            : base(httpClient: httpClient, apiKey: apiKey, apiSecret: apiSecret, url: url, recvWindow: recvWindow, debugMode: debugMode)
        {
        }

        private const string GET_AFFILIATE_USER_LIST = "/v5/affiliate/aff-user-list";

        /// <summary>
        /// Get Affiliate User List
        /// Requires master UID and API key with only "Affiliate" permission.
        /// </summary>
        /// <param name="size">[0,1000], default 0</param>
        /// <param name="cursor">pagination cursor</param>
        /// <param name="needDeposit">include deposit info</param>
        /// <param name="need30">include last 30d trading info</param>
        /// <param name="need365">include last 365d trading info</param>
        /// <returns></returns>
        public async Task<string?> GetAffiliateUserList(
            int? size = null,
            string? cursor = null,
            bool? needDeposit = null,
            bool? need30 = null,
            bool? need365 = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("size", size),
                ("cursor", cursor),
                ("needDeposit", needDeposit),
                ("need30", need30),
                ("need365", need365)
            );

            var result = await this.SendSignedAsync<string>(GET_AFFILIATE_USER_LIST, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_AFFILIATE_USER_INFO = "/v5/user/aff-customer-info";

        /// <summary>
        /// Get Affiliate User Info
        /// Requires master UID and API key with only "Affiliate" permission.
        /// </summary>
        /// <param name="uid">Affiliate client's master UID</param>
        /// <returns></returns>
        public async Task<string?> GetAffiliateUserInfo(string uid)
        {
            var query = new Dictionary<string, object> { { "uid", uid } };
            var result = await this.SendSignedAsync<string>(GET_AFFILIATE_USER_INFO, HttpMethod.Get, query: query);
            return result;
        }

    }
}

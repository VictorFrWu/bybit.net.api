using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.User
{
    public class GetSubAccountAllApiKeysResult
    {
        public List<SubApiKeyInfo>? result { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class SubApiKeyInfo
    {
        public string? id { get; set; }                    // internal id
        public List<string>? ips { get; set; }             // IP bound
        public string? apiKey { get; set; }
        public string? note { get; set; }
        public int? status { get; set; }                   // 1 permanent, 2 expired, 3 valid, 4 expires soon
        public string? expiredAt { get; set; }             // datetime
        public string? createdAt { get; set; }             // datetime
        public int? type { get; set; }                     // 1 personal, 2 third-party app
        public ApiKeyPermissions? permissions { get; set; }
        public string? secret { get; set; }                // "******"
        public bool? readOnly { get; set; }
        public int? deadlineDay { get; set; }              // remaining valid days
        public string? flag { get; set; }                  // api key type
    }

    public class ApiKeyPermissions
    {
        public List<string>? ContractTrade { get; set; }   // Order, Position
        public List<string>? Spot { get; set; }            // SpotTrade
        public List<string>? Wallet { get; set; }          // AccountTransfer, SubMemberTransferList
        public List<string>? Options { get; set; }         // OptionsTrade
        public List<string>? Derivatives { get; set; }     // DerivativesTrade
        public List<string>? Exchange { get; set; }        // ExchangeHistory
        public List<string>? Earn { get; set; }            // Earn
        public List<string>? CopyTrading { get; set; }     // []
        public List<string>? BlockTrade { get; set; }      // []
        public List<string>? NFT { get; set; }             // deprecated []
        public List<string>? Affiliate { get; set; }       // []
    }

}

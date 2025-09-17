using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Asset
{
    public class GetConvertHistoryResult
    {
        public List<ConvertHistoryItem>? list { get; set; }
    }

    public class ConvertHistoryItem
    {
        public string? accountType { get; set; }
        public string? exchangeTxId { get; set; }
        public string? userId { get; set; }
        public string? fromCoin { get; set; }
        public string? fromCoinType { get; set; } // crypto
        public string? toCoin { get; set; }
        public string? toCoinType { get; set; }   // crypto
        public string? fromAmount { get; set; }
        public string? toAmount { get; set; }
        public string? exchangeStatus { get; set; } // init, processing, success, failure
        public ExtInfo? extInfo { get; set; }
        public string? convertRate { get; set; }
        public string? createdAt { get; set; }
    }

    public class ExtInfo
    {
        public string? paramType { get; set; }
        public string? paramValue { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Asset
{
    public class GetConvertStatusResult
    {
        public ConvertResult? result { get; set; }
    }

    public class ConvertResult
    {
        public string? accountType { get; set; }
        public string? exchangeTxId { get; set; } // same as quoteTxId
        public string? userId { get; set; }
        public string? fromCoin { get; set; }
        public string? fromCoinType { get; set; } // crypto
        public string? toCoin { get; set; }
        public string? toCoinType { get; set; }   // crypto
        public string? fromAmount { get; set; }
        public string? toAmount { get; set; }
        public string? exchangeStatus { get; set; } // init, processing, success, failure
        public object? extInfo { get; set; }        // reserved
        public string? convertRate { get; set; }
        public string? createdAt { get; set; }
    }

}

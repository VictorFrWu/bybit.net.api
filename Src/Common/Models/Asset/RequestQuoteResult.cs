using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Asset
{
    public class RequestQuoteResult
    {
        public string? quoteTxId { get; set; }
        public string? exchangeRate { get; set; }
        public string? fromCoin { get; set; }
        public string? fromCoinType { get; set; }
        public string? toCoin { get; set; }
        public string? toCoinType { get; set; }
        public string? fromAmount { get; set; }
        public string? toAmount { get; set; }
        public string? expiredTime { get; set; }
        public string? requestId { get; set; }
        public List<object>? extTaxAndFee { get; set; }
    }

}

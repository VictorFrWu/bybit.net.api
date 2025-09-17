using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Position.Response
{
    public class GetClosedOptionsPositionsResult
    {
        public string? nextPageCursor { get; set; }
        public string? category { get; set; }
        public List<ClosedOptionsPosition>? list { get; set; }
    }

    public class ClosedOptionsPosition
    {
        public string? symbol { get; set; }
        public string? side { get; set; }
        public string? totalOpenFee { get; set; }
        public string? deliveryFee { get; set; }
        public string? totalCloseFee { get; set; }
        public string? qty { get; set; }
        public long? closeTime { get; set; }
        public string? avgExitPrice { get; set; }
        public string? deliveryPrice { get; set; }
        public long? openTime { get; set; }
        public string? avgEntryPrice { get; set; }
        public string? totalPnl { get; set; }
    }
}

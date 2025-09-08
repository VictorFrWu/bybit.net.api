using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Asset
{
    public class GetDeliveryRecordResult
    {
        public string? category { get; set; }
        public List<DeliveryRecord>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class DeliveryRecord
    {
        public long? deliveryTime { get; set; }   // ms
        public string? symbol { get; set; }
        public string? side { get; set; }         // Buy, Sell
        public string? position { get; set; }     // executed size
        public string? entryPrice { get; set; }
        public string? deliveryPrice { get; set; }
        public string? strike { get; set; }
        public string? fee { get; set; }
        public string? deliveryRpl { get; set; }  // realized PnL of the delivery
    }

}

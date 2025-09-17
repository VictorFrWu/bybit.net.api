using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Market
{
    public class GetNewDeliveryPriceResult
    {
        public string? category { get; set; }
        public List<NewDeliveryPriceItem>? list { get; set; }
    }

    public class NewDeliveryPriceItem
    {
        public string? deliveryPrice { get; set; }
        public string? deliveryTime { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class GetRfqConfigResponse
    {
        public List<string>? result { get; set; }   // Order ID
        public RfqConfig? list { get; set; }
    }

    public class RfqConfig
    {
        public string? deskCode { get; set; }                 // your deskCode
        public int? maxLegs { get; set; }                     // max legs
        public int? maxLP { get; set; }                       // max LPs selectable
        public int? maxActiveRfq { get; set; }                // max unfinished RFQs
        public int? rfqExpireTime { get; set; }               // minutes
        public int? minLimitQtySpotOrder { get; set; }        // spot min qty
        public int? minLimitQtyContractOrder { get; set; }    // contract min qty
        public int? minLimitQtyOptionOrder { get; set; }      // option min qty
        public List<RfqStrategyType>? strategyTypes { get; set; }
        public List<RfqCounterparty>? counterparties { get; set; }
    }

    public class RfqStrategyType
    {
        public string? strategyName { get; set; }
    }

    public class RfqCounterparty
    {
        public string? traderName { get; set; }   // quoter name
        public string? deskCode { get; set; }     // quoter desk code
        public string? type { get; set; }         // LP | null (normal)
    }
}

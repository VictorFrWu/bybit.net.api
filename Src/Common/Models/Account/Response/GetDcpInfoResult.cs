using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Account.Response
{
    public class GetDcpInfoResult
    {
        public List<DcpInfo>? dcpInfos { get; set; }
    }

    public class DcpInfo
    {
        public string? product { get; set; }     // SPOT, DERIVATIVES, OPTIONS
        public string? dcpStatus { get; set; }   // ON
        public string? timeWindow { get; set; }  // seconds
    }

}

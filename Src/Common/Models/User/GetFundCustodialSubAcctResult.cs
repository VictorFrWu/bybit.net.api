using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.User
{
    public class GetFundCustodialSubAcctResult
    {
        public List<EscrowSubMember>? subMembers { get; set; }
        public string? nextCursor { get; set; } // "0" => no more pages
    }

    public class EscrowSubMember
    {
        public string? uid { get; set; }
        public string? username { get; set; }
        public int? memberType { get; set; }  // 12: fund custodial sub account
        public int? status { get; set; }      // 1 normal, 2 login banned, 4 frozen
        public int? accountMode { get; set; } // 1 classic, 3 UTA
        public string? remark { get; set; }
    }

}

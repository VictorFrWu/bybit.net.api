using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.User
{
    public class GetSubUidListLimitedResult
    {
        public List<SubMember>? subMembers { get; set; }
    }

    public class SubMember
    {
        public string? uid { get; set; }
        public string? username { get; set; }
        public int? memberType { get; set; }  // 1 normal, 6 custodial
        public int? status { get; set; }      // 1 normal, 2 login banned, 4 frozen
        public int? accountMode { get; set; } // 1 classic, 3 UTA
        public string? remark { get; set; }
    }
}

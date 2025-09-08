using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Asset
{
    public class GetExchangeEntityListResult
    {
        public List<VaspEntity>? vasp { get; set; }
    }

    public class VaspEntity
    {
        public string? vaspEntityId { get; set; }
        public string? vaspName { get; set; }
    }

}

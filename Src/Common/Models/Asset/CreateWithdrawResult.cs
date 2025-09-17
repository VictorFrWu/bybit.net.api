using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Asset
{
    public class CreateWithdrawResult
    {
        public string? id { get; set; }
    }

    public class Beneficiary
    {
        public string? vaspEntityId { get; set; }
        public string? beneficiaryName { get; set; }
        public string? beneficiaryLegalType { get; set; }           // individual, company
        public string? beneficiaryWalletType { get; set; }          // 0 custodial/exchange, 1 non-custodial
        public string? beneficiaryUnhostedWalletType { get; set; }  // 0 your own, 1 others'
        public string? beneficiaryPoiNumber { get; set; }
        public string? beneficiaryPoiType { get; set; }
        public string? beneficiaryPoiIssuingCountry { get; set; }   // Alpha-3
        public string? beneficiaryPoiExpiredDate { get; set; }      // yyyy-mm-dd
        public string? beneficiaryAddressCountry { get; set; }      // Alpha-3
        public string? beneficiaryAddressState { get; set; }
        public string? beneficiaryAddressCity { get; set; }
        public string? beneficiaryAddressBuilding { get; set; }
        public string? beneficiaryAddressStreet { get; set; }
        public string? beneficiaryAddressPostalCode { get; set; }
        public string? beneficiaryDateOfBirth { get; set; }         // yyyy-mm-dd
        public string? beneficiaryPlaceOfBirth { get; set; }
    }

}

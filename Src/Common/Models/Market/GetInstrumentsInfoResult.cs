using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Market
{
    public class GetInstrumentsInfoResult
    {
        public string? category { get; set; }
        public string? nextPageCursor { get; set; }
        public List<InstrumentInfo>? list { get; set; }
    }

    public class InstrumentInfo
    {
        public string? symbol { get; set; }
        public string? contractType { get; set; }
        public string? status { get; set; }
        public string? baseCoin { get; set; }
        public string? quoteCoin { get; set; }
        public string? launchTime { get; set; }
        public string? deliveryTime { get; set; }
        public string? deliveryFeeRate { get; set; }
        public string? priceScale { get; set; }
        public LeverageFilter? leverageFilter { get; set; }
        public PriceFilter? priceFilter { get; set; }
        public LotSizeFilter? lotSizeFilter { get; set; }
        public bool? unifiedMarginTrade { get; set; }
        public int? fundingInterval { get; set; }
        public string? settleCoin { get; set; }
        public string? copyTrading { get; set; }
        public string? upperFundingRate { get; set; }
        public string? lowerFundingRate { get; set; }
        public string? displayName { get; set; }
        public RiskParameters? riskParameters { get; set; }
        public bool? isPreListing { get; set; }
        public PreListingInfo? preListingInfo { get; set; }
    }

    public class LeverageFilter
    {
        public string? minLeverage { get; set; }
        public string? maxLeverage { get; set; }
        public string? leverageStep { get; set; }
    }

    public class PriceFilter
    {
        public string? minPrice { get; set; }
        public string? maxPrice { get; set; }
        public string? tickSize { get; set; }
    }

    public class LotSizeFilter
    {
        public string? minNotionalValue { get; set; }
        public string? maxOrderQty { get; set; }
        public string? maxMktOrderQty { get; set; }
        public string? minOrderQty { get; set; }
        public string? qtyStep { get; set; }
        public string? postOnlyMaxOrderQty { get; set; } // deprecated
    }

    public class RiskParameters
    {
        public string? priceLimitRatioX { get; set; }
        public string? priceLimitRatioY { get; set; }
    }

    public class PreListingInfo
    {
        public string? curAuctionPhase { get; set; }
        public List<PreListingPhase>? phases { get; set; }
        public AuctionFeeInfo? auctionFeeInfo { get; set; }
    }

    public class PreListingPhase
    {
        public string? phase { get; set; }
        public string? startTime { get; set; }
        public string? endTime { get; set; }
    }

    public class AuctionFeeInfo
    {
        public string? auctionFeeRate { get; set; }
        public string? takerFeeRate { get; set; }
        public string? makerFeeRate { get; set; }
    }

}

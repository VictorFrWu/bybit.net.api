namespace bybit.net.api.Models
{
    public class OrderRequest
    {
        public Category Category { get; set; } // Product type: Unified account or Classic account
        public string? Symbol { get; set; } // Symbol name
        public bool? IsLeverage { get; set; } // Whether to borrow: 0 (false) or 1 (true)
        public Side? Side { get; set; } // Buy or Sell
        public OrderType? OrderType { get; set; } // Market or Limit
        public string? Qty { get; set; } // Order quantity
        public string? Price { get; set; } // Order price
        public TriggerDirection? TriggerDirection { get; set; } // Conditional order param
        public string? OrderFilter { get; set; } // Order or tpslOrder or StopOrder
        public string? TriggerPrice { get; set; } // Conditional order trigger price
        public TriggerBy? TriggerBy { get; set; } // Trigger price type: LastPrice, IndexPrice, MarkPrice
        public string? OrderIv { get; set; } // Implied volatility
        public TimeInForce? TimeInForce { get; set; } // Time in force
        public PositionIndex? PositionIdx { get; set; } // Position mode identifier
        public string? OrderLinkId { get; set; } // User customised order ID
        public string? TakeProfit { get; set; } // Take profit price
        public string? StopLoss { get; set; } // Stop loss price
        public TriggerBy? TpTriggerBy { get; set; } // Price type to trigger take profit
        public TriggerBy? SlTriggerBy { get; set; } // Price type to trigger stop loss
        public bool? ReduceOnly { get; set; } // Reduce-only order flag
        public bool? CloseOnTrigger { get; set; } // Close on trigger order flag
        public SmpType? SmpType { get; set; } // Smp execution type
        public bool? Mmp { get; set; } // Market maker protection flag
        public TpslMode? TpslMode { get; set; } // TP/SL mode: Full or Partial
        public string? TpLimitPrice { get; set; } // Limit order price when take profit is triggered
        public string? SlLimitPrice { get; set; } // Limit order price when stop loss is triggered
        public OrderType? TpOrderType { get; set; } // Order type when take profit is triggered
        public OrderType? SlOrderType { get; set; } // Order type when stop loss is triggered
    }

}

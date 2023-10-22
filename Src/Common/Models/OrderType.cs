namespace bybit.net.api.Models
{
    public struct OrderType
    {
        private OrderType(string value)
        {
            this.Value = value;
        }

        public static OrderType LIMIT { get => new("Limit"); }
        public static OrderType MARKET { get => new("Market"); }
        public string Value { get; private set; }
        public static implicit operator string(OrderType enm) => enm.Value;
        public override string ToString() => this.Value.ToString();
    }
}

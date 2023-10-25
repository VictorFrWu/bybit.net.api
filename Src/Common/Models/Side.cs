namespace bybit.net.api.Models
{
    public struct Side
    {
        private Side(string value)
        {
            this.Value = value;
        }

        public static Side BUY { get => new("Buy"); }
        public static Side SELL { get => new("Sell"); }
        public string Value { get; private set; }
        public static implicit operator string(Side enm) => enm.Value;
        public override readonly string ToString() => this.Value.ToString();
    }
}

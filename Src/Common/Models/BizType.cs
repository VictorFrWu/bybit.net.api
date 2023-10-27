namespace bybit.net.api.Models
{
    public struct BizType
    {
        private BizType(string value)
        {
            this.Value = value;
        }

        public static BizType SPOT { get => new("SPOT"); }
        public static BizType DERIVATIVES { get => new("DERIVATIVES"); }
        public static BizType OPTIONS { get => new("OPTIONS"); }
        public string Value { get; private set; }
        public static implicit operator string(BizType bizType) => bizType.Value;
        public override readonly string ToString() => this.Value.ToString();
    }
}
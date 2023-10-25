namespace bybit.net.api.Models
{
    public struct CollateralSwitch
    {
            private CollateralSwitch(string value)
            {
                this.Value = value;
            }

            public static CollateralSwitch ON { get => new("ON"); }
            public static CollateralSwitch OFF { get => new("OFF"); }
            public string Value { get; private set; }
            public static implicit operator string(CollateralSwitch enm) => enm.Value;
            public override readonly string ToString() => this.Value.ToString();
        }
}

namespace bybit.net.api.ApiServiceImp
{
    public struct Switch
    {
        private Switch(int value)
        {
            Value = value;
        }

        public static Switch TurnOffQuickLogin => new(0);
        public static Switch TurnOnQuickLogin => new(1);

        public int Value { get; private set; }

        public override readonly string ToString() => Value.ToString();

        public static implicit operator int(Switch switchValue) => switchValue.Value;
    }
}
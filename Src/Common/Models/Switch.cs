namespace bybit.net.api.ApiServiceImp
{
    public struct Switch
    {
        private Switch(int value)
        {
            Value = value;
        }

        public static Switch TurnOffQuickLogin => new Switch(0);
        public static Switch TurnOnQuickLogin => new Switch(1);

        public int Value { get; private set; }

        public override string ToString() => Value.ToString();

        public static implicit operator int(Switch switchValue) => switchValue.Value;
    }
}
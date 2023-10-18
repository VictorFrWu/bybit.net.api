namespace bybit.net.api
{
    public static class BybitConstants
    {
        public const string MAINNET_URL = "https://api.bybit.com";
        public const string TESTNET_URL = "https://api-testnet.bybit.com";
        public const string DEFAULT_REC_WINDOW = "5000";
        public const string DEFAULT_SIGN_TYPE = "2";
        #region V5
        public const string TESTNET_WS_URL_PUBLIC = "wss://stream-testnet.bybit.com";
        public const string TESTNET_WS_URL_PRIVATE = "wss://stream-testnet.bybit.com";
        public const string WS_URL_PUBLIC = "wss://stream.bybit.com/v5";
        public const string WS_API_PRIVATE = "wss://stream.bybit.com/v5/private";
        public const string V5_PUBLIC_SPOT = "/v5/public/spot";
        public const string V5_PUBLIC_LINEAR = "/v5/public/linear";
        public const string V5_PUBLIC_INVERSE = "/v5/public/inverse";
        public const string V5_PUBLIC_OPTION = "/v5/public/option";
        public const string V5_PRIVATE = "/v5/private";
        #endregion
        #region V3
        public const string V3_PUBLIC_OPTION = "/option/usdc/public/v3";
        public const string V3_CONTRACT_PRIVATE = "/contract/private/v3";
        public const string V3_UNIFIED_PRIVATE = "/unified/private/v3";
        public const string V3_CONTRACT_USDT_PUBLIC = "/contract/usdt/public/v3";
        public const string V3_SPOT_PRIVATE = "/spot/private/v3";
        #endregion
    }
}

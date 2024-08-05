namespace WPFAppConverter.Core.CoinAnalitic
{
    public struct CoinStruct
    {
        public string id;
        public string rank;
        public string symbol;
        public string name;

        public decimal supply;
        public decimal? maxSupply;
        public decimal marketCapUsd;
        public decimal volumeUsd24Hr;
        public decimal priceUsd;
        public decimal changePercent24Hr;
        public decimal vwap24Hr;
    }

    /* The structure is taken from the data API format. */
}

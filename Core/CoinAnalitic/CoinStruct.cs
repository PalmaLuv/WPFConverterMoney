using Newtonsoft.Json;

namespace WPFAppConverter.Core.CoinAnalitic
{
    /* The structure is taken from the data API format. */

    public struct CoinStruct        // Asset structure
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }

        public decimal? supply { get; set; }
        public decimal? maxSupply { get; set; }
        public decimal? marketCapUsd { get; set; }
        public decimal? volumeUsd24Hr { get; set; }
        public decimal? priceUsd { get; set; }
        public decimal? changePercent24Hr { get; set; }
        public decimal? vwap24Hr { get; set; }
    }

    public struct CoinStructMarkets // Asset markets structure
    {
        public string exchangeId { get; set; }

        [JsonProperty("baseId")]
        public string id { get; set; }

        public string quoteId { get; set; }
        public string baseSymbol { get; set; }
        public string USDT { get; set; }

        public decimal volumeUsd24Hr { get; set; }
        public decimal priceUsd { get; set; }
        public decimal volumePercent { get; set; }
    }

    public enum RatesType
    {
        fiat, crypto
    }

    public struct CoinStructRates // Rates structure
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string currencySymbol { get; set; }

        public RatesType type { get; set; }

        public decimal rateUsd { get; set; }
    }

    public struct CoinStructHistory // Asset history structure
    {
        public decimal priceUsd { get; set; }
        public decimal? circulatingSupply { get; set; }

        public long time { get; set; }

        public DateTime date { get; set; }

    }

    public struct CoinStructCandles // Candles structure 
    {
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low  { get; set; }
        public decimal close { get; set; }
        public decimal volume { get; set; }
        
        public long period { get; set; }
    }

    public struct CoinStructExchanges // Exchanges structure
    {
        public string id    { get; set; }
        public string name  { get; set; }
        // Url webSite
        public string exchangeUrl { get; set; } 

        public int rank { get; set; }

        public decimal? percentTotalVolume   { get; set; }
        public decimal? volumeUsd            { get; set; }  

        public int tradingPairs { get; set; }

        public bool? socket      { get; set; }

        // This property will store the raw UNIX timestamp in milliseconds from the JSON
        [JsonProperty("updated")]
        public long UnixTimestamp { get; set; }

        // This property will convert the UNIX timestamp to DateTime
        [JsonIgnore]
        public DateTime updated
        {
            get
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(UnixTimestamp).LocalDateTime;
            }
        }
    }
}
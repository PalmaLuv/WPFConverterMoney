using Newtonsoft.Json;
using OpenTK.Compute.OpenCL;

namespace WPFAppConverter.Core.CoinAnalitic
{
    /* The structure is taken from the data API format. */
    public struct CoinStruct        // Coin struct
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }

        public decimal supply { get; set; }
        public decimal? maxSupply { get; set; }
        public decimal marketCapUsd { get; set; }
        public decimal volumeUsd24Hr { get; set; }
        public decimal priceUsd { get; set; }
        public decimal changePercent24Hr { get; set; }
        public decimal vwap24Hr { get; set; }
    }

    public struct CoinStructMarkets // Market struct
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

    public struct CoinStructRates // Rates struct
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string currencySymbol { get; set; }

        public RatesType type { get; set; }

        public decimal rateUsd { get; set; }
    }

    public struct CoinStructHistory // History struct
    {
        public decimal priceUsd { get; set; }
        public decimal? circulatingSupply { get; set; }

        public long time { get; set; }

        public DateTime date { get; set; }

    }

    public struct CoinStructCandles // Candles strict 
    {
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low  { get; set; }
        public decimal close { get; set; }
        public decimal volume { get; set; }
        
        public long period { get; set; }
    }
}

/*
 
"open": "0.0708000000000000",
      "high": "0.0710450000000000",
      "low": "0.0706434000000000",
      "close": "0.0708350100000000",
      "volume": "1818.1433015300000000",
      "period": 1530720000000
 
 */
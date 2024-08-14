using System.Net.Http;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace WPFAppConverter.Core.CoinAnalitic
{
    class CoinCap
    {
        // Creating and configuring HttpClient to execute HTTP requests
        // Set the base address for all requests made by this HttpClient instance
        // All relative URLs in requests will be automatically appended with this base address
        private static readonly HttpClient _client = new HttpClient
        { BaseAddress = new Uri("https://api.coincap.io") };

        /// <summary>
        /// GET /assets/{{id}}/ markets
        /// </summary>
        /// <param name="id">asset id</param>
        /// <param name="option">
        ///     limit - max limit of 2000
        ///     offset - offset
        /// </param>
        public async Task<Dictionary<string, CoinStructMarkets>> GetElementMarkets(string id, string option = "")
        {
            var result = new Dictionary<string, CoinStructMarkets>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/assets/{id.ToLower()}/markets" + option)
                { Content = new StringContent("", null, "text/paint") };
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var dataArray = jsonObject["data"] as JArray;
                if (dataArray != null)
                    foreach (var item in dataArray)
                    {
                        var idMarket = item["exchangeId"]?.ToString();
                        if (idMarket != null)
                            result.Add(idMarket, item.ToObject<CoinStructMarkets>());
                    }
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        /// <summary>
        /// GET /assets/{{id}}/ history
        /// </summary>
        /// <param name="id">assets id</param>
        /// <param name="interval">intervar = [ m1, m5, m15, m30, h1, h2, h6, h12, d1 ]</param>
        /// <param name="option">
        ///     start & end - UNIX time in milliseconds.
        /// </param>
        public async Task<List<CoinStructHistory>> GetHistory(string id, string interval, string option = "")
        {
            var result = new List<CoinStructHistory>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/assets/{id.ToLower()}/history?interval={interval.ToLower()}" + option);
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var dataArray = jsonObject["data"] as JArray;
                if (dataArray != null)
                    foreach (var item in dataArray)
                        result.Add(item.ToObject<CoinStructHistory>());
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        /// <summary>
        /// GET /candles 
        /// </summary>
        /// <param name="id">quote id</param>
        /// <param name="exchange">exchange id</param>
        /// <param name="interval">intervar = [ m1, m5, m15, m30, h1, h2, h6, h12, d1 ] candle interval</param>
        /// <param name="baseId">base id</param>
        /// <param name="option">
        ///     start & end - UNIX time in milliseconds. omiting will return the most recent candles
        /// </param>
        public async Task<List<CoinStructCandles>> GetCandles(string id, string exchange, string interval, string baseId, string option = "")
        {
            var result = new List<CoinStructCandles>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/candles?exchange={exchange.ToLower()}&interval={interval.ToLower()}" +
                    $"&baseId={baseId.ToLower()}&quoteId={id.ToLower()}" + option);
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var dataArray = jsonObject["data"] as JArray;
                if (dataArray != null)
                    foreach (var item in dataArray)
                        result.Add(item.ToObject<CoinStructCandles>());
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        /// <summary>
        /// GET /assets
        /// </summary>
        /// <param name="option">
        ///     search - search by asset id (bitcoin) or symbol (BTC);
        ///     ids - query with multiple ids=bitcoin,ethereum,monero;
        ///     limit - max limit of 2000;
        ///     offset - offset;
        /// </param>
        public async Task<Dictionary<string, CoinStruct>> GetAssetsAll(string option = "")
        {
            var result = new Dictionary<string, CoinStruct>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "/v2/assets" + option);
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var dataArray = jsonObject["data"] as JArray;
                if (dataArray != null)
                    foreach (var item in dataArray)
                    {
                        var id = item["id"]?.ToString();
                        if (id != null)
                            result.Add(id, item.ToObject<CoinStruct>());
                    }
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        /// <summary>
        /// GET /assets/{{id}}
        /// </summary>
        /// <param name="id">asset id</param>
        public async Task<CoinStruct> GetAssets(string id)
        {
            var result = new CoinStruct();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/assets/{id.ToLower()}");
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var dataArray = jsonObject["data"] as JArray;
                if (dataArray != null)
                    result = dataArray[0].ToObject<CoinStruct>();
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        /// <summary>
        /// GET /rates
        /// </summary>
        public async Task<Dictionary<string, CoinStructRates>> GetRatesAll()
        {
            var result = new Dictionary<string, CoinStructRates>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "/v2/rates");
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var dataArray = jsonObject["data"] as JArray;
                if (dataArray != null)
                    foreach (var item in dataArray)
                    {
                        var id = item["id"]?.ToString();
                        if (id != null)
                            result.Add(id, item.ToObject<CoinStructRates>());
                    }
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        /// <summary>
        /// GET /rates/{{id}}
        /// </summary>
        /// <param name="id">asset id</param>
        public async Task<CoinStructRates> GetRates(string id)
        {
            var result = new CoinStructRates();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/rates/{id.ToLower()}");
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var dataArray = jsonObject["data"] as JArray;
                if (dataArray != null)
                    result = dataArray[0].ToObject<CoinStructRates>();
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        /// <summary>
        /// Get /exchanges/
        /// </summary>
        public async Task<Dictionary<string, CoinStructExchanges>> GetExchanges()
        {
            var result = new Dictionary<string, CoinStructExchanges>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "/v2/exchanges");
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var dataArray = jsonObject["data"] as JArray;
                if (dataArray != null)
                    foreach (var item in dataArray)
                    {
                        var id = item["exchangeId"]?.ToString();
                        if (id != null)
                            result.Add(id, item.ToObject<CoinStructExchanges>());
                    }
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        /// <summary>
        /// Get count element
        /// </summary>
        /// <param name="command">array string[] {"/assets", "/markets", ... } </param>
        /// <returns>Number of items for different queries</returns>
        public async Task<List<int>> GetElementCount(string[] command)
        {
            var result = new List<int>();
            try
            {
                for (int i = 0; i <  command.Length; i++)
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, command[i]);
                    var response = await _client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    var dataArray = jsonObject["data"] as JArray;
                    if (dataArray.Count != null)
                        result.Add(dataArray.Count);
                    else
                        result.Add(0);
                }
            }
            catch (HttpRequestException e)
            {
                HandleException(e);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return result;
        }

        // Displaying an error in MessageBox
        private void HandleException(Exception ex) =>
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}

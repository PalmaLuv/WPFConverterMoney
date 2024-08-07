using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Windows;

namespace WPFAppConverter.Core.CoinAnalitic
{
    class CoinCap : ObservableObject
    {
        private static readonly HttpClient _client = new HttpClient
        { BaseAddress = new Uri("https://api.coincap.io") };

        public async Task<Dictionary<string, CoinStructMarkets>> GetElementMarkets(string id)
        {
            var result = new Dictionary<string, CoinStructMarkets>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/assets/{id.ToLower()}/marjets")
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
        /// History assets
        /// </summary>
        /// <param name="id">assets id</param>
        /// <param name="interval">intervar = [ m1, m5, m15, m30, h1, h2, h6, h12, d1 ]</param>
        public async Task<List<CoinStructHistory>> GetHistory(string id, string interval)
        {
            var result = new List<CoinStructHistory>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/assets/{id.ToLower()}/history?interval={interval.ToLower()}");
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

        private void HandleException(Exception ex) =>
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}

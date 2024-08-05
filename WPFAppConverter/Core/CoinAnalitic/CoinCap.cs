using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
using System.Text.Json;
using System.Windows.Controls;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WPFAppConverter.Core.CoinAnalitic
{
    class CoinCap
    {
        private static readonly HttpClient _client = new HttpClient 
        { BaseAddress = new Uri("https://api.coincap.io") };

        public async Task GetElementMarkets(string id)
        {
            try
            {

            }
            catch (HttpRequestException e)
            {
                 
            }
            catch (Exception e)
            {

            }
        }

        public async Task<Dictionary<string, CoinStruct>> GetAll()
        {
            var result = new Dictionary<string, CoinStruct>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "/v2/assets");
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

        public async Task<CoinStruct> GetElement(string id)
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

        private void HandleException(Exception ex) =>
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}

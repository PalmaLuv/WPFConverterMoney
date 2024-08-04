using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace WPFAppConverter.Core.CoinAnalitic
{
    struct CoinStr
    {
        public string id;
        public string rank;
        public string symbol;
        public string name;

        public long supply;
        public long maxSupply;
        public long marketCapUsd;
        public long volumeUsd24Hr;
        public long priceUsd;
        public long changePercent24Hr;
        public long vwap24Hr;
    }

    class CoinCap
    {
        private string _apiURL = "api.coincap.io/v2/assets";

        public CoinCap ()
        { }

        public async void GetAll()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "api.coincap.io/v2/assets/bitcoin");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            MessageBox.Show(await response.Content.ReadAsStringAsync());


/*            using (var client = new HttpClient())
            using (var reques = new HttpRequestMessage(HttpMethod.Get, "api.coincap.io/v2/assets/bitcoin"))
            {
                var responce = await client.SendAsync(reques);
                responce.EnsureSuccessStatusCode();
                MessageBox.Show(await responce.Content.ReadAsStringAsync());
            }*/
        }
         
    }
}

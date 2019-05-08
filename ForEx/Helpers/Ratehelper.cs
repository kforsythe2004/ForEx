using ForEx.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForEx.Helpers
{
    public class RateHelper
    {
        Exchange _exchange;
        Country[] _cntry;

        public RateHelper()
        {

            _exchange = GetRates();

            string path = string.Format("{0}{1}", Environment.CurrentDirectory, "\\JsonData\\country.json");
            string jsonData = System.IO.File.ReadAllText(path);
            _cntry = JsonConvert.DeserializeObject<Country[]>(jsonData);
        }


        public Exchange GetRates()
        {
            var t = GetRateData();
            Exchange ex = t.Result;

            return ex;
        }



    private async Task<Exchange> GetRateData()
        {
            Exchange ex;

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://openexchangerates.org/api/latest.json?app_id=925b5c034e404a678862b0ea49a2fab6");
                response.EnsureSuccessStatusCode();
                string resp = await response.Content.ReadAsStringAsync();
                ex = JsonConvert.DeserializeObject<Exchange>(resp);
            }
            catch (Exception e)
            {

                throw e;
            }


            return ex;
        }


        public Country[] GetCountryData()
        {

            return _cntry;
        }



        public decimal ConvertToNative(fxAsset a, string countryCode)
    {
        decimal nativeAmount = 0;

        nativeAmount = (a.amount / _exchange.rates[a.currencyCode]) * _exchange.rates[_cntry.Single(x => x.code == countryCode).currencyCode];

            return nativeAmount;
    }
}
}

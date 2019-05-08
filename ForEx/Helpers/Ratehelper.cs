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
        Currency[] _currency;
        portfolio[] _ports;

        public RateHelper()
        {
            // load up instance variables with a current feed from the exchange web site, and with static json files
            _exchange = GetRates();

            string path = string.Format("{0}{1}", Environment.CurrentDirectory, "\\JsonData\\country.json");
            string jsonData = System.IO.File.ReadAllText(path);
            _cntry = JsonConvert.DeserializeObject<Country[]>(jsonData);

            path = string.Format("{0}{1}", Environment.CurrentDirectory, "\\JsonData\\currencyCode.json");
            jsonData = System.IO.File.ReadAllText(path);
           _currency = JsonConvert.DeserializeObject<Currency[]>(jsonData);

            path = string.Format("{0}{1}", Environment.CurrentDirectory, "\\JsonData\\portfolio.json");
            jsonData = System.IO.File.ReadAllText(path);
            _ports = JsonConvert.DeserializeObject<portfolioRoot>(jsonData).portfolios;
        }


        // Make Http request to get current data
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


        // Get currency symbols for assets and country default currency
        public string GetSymbol(string currencyCode)
        {
            return _currency.Single(c => c.isoCode == currencyCode).symbol;
        }

        public string GetNativeSymbol(string countryCode)
        {
            return GetSymbol(_cntry.Single(c => c.code == countryCode).currencyCode);

        }


        // Simple getters to return the static json data

        public portfolio[] GetPortfolios()
        {
            return _ports;
        }

        public Currency[] GetCurrency()
        {
            return _currency;
        }
      
        public Country[] GetCountry()
        {
            return _cntry;
        }


        // helper method to convert financial asset amount from its currency to the default of the country identified on the portfolio
        public decimal ConvertToNative(fxAsset a, string countryCode)
    {
        decimal nativeAmount = 0;

        // since the exchange rates are all based on USD, divide by the fxAsset currency rate to get a USD value, then multiply by the country's exchange rate to convert from USD to the native currency
        nativeAmount = (a.amount / _exchange.rates[a.currencyCode]) * _exchange.rates[_cntry.Single(x => x.code == countryCode).currencyCode];

            return nativeAmount;
    }
}
}

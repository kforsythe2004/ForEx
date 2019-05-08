using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForEx.Models;
using Newtonsoft.Json;
using ForEx.Helpers;

namespace ForEx.Controllers
{
    public class HomeController : Controller
    {
        // // // // // // // // // // // // // // // // // // // // // // // //
        //
        // This section handles basic page loading
        //
        // // // // // // // // // // // // // // // // // // // // // // // //

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult portfolio()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }

        public IActionResult Currency()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        // // // // // // // // // // // // // // // // // // // // // // // //
        //
        // This section handles ajax data requests
        //
        // // // // // // // // // // // // // // // // // // // // // // // //

        public IActionResult Country()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // POST <controller>/getdata
        [HttpGet]
        public portfolio[] getdata()
        {
            RateHelper rh = new RateHelper();

            // Get portfolio data and current exchange rates
            portfolio[] ports = rh.GetPortfolios();
            Exchange ex = rh.GetRates();


            // cycle through each portfolio and then each asset
            // Calculate the value in the native currency for that country
            // populate currency symbols

            ports.ToList().ForEach(x =>
            {
                x.value = 0;
                x.nativeSymbol = rh.GetNativeSymbol(x.countryCode);

                x.fxAssets.ToList().ForEach(a =>
                {
                    x.value += rh.ConvertToNative(a, x.countryCode);
                    
                });

                x.intrinsicValue += rh.ConvertToUSD(x.value, x.countryCode);
            });
            return ports.OrderByDescending(x => x.intrinsicValue).ToArray();
        }



        // POST <controller>/getportfolios
        [HttpGet]
        public portfolio[] getportfolios()
        {
            RateHelper rh = new RateHelper();

            return rh.GetPortfolios();
        }


        // POST <controller>/getcurrency
        [HttpGet]
        public Currency[] getcurrency()
        {
            RateHelper rh = new RateHelper();

            return rh.GetCurrency();
        }

        // POST <controller>/getcountries
        [HttpGet]
        public Country[] getcountries()
        {
            RateHelper rh = new RateHelper();

            return rh.GetCountry();
        }
    }
}

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
            string path = string.Format("{0}{1}", Environment.CurrentDirectory, "\\JsonData\\portfolio.json");
            string jsonData = System.IO.File.ReadAllText(path);
            portfolioRoot ports = JsonConvert.DeserializeObject<portfolioRoot>(jsonData);

            RateHelper rh = new RateHelper();

            Exchange ex = rh.GetRates();

            ports.portfolios.ToList().ForEach(x =>
            {
                x.fxAssets.ToList().ForEach(a =>
                {
                    a.nativeAmount = rh.ConvertToNative(a, x.countryCode);

                });
                
            });
            return ports.portfolios;
        }



        // POST <controller>/getportfolios
        [HttpGet]
        public portfolio[] getportfolios()
        {
            string path = string.Format("{0}{1}", Environment.CurrentDirectory, "\\JsonData\\portfolio.json");
            string jsonData = System.IO.File.ReadAllText(path);
            portfolioRoot ports = JsonConvert.DeserializeObject<portfolioRoot>(jsonData);

            return ports.portfolios;
        }


        // POST <controller>/getcurrency
        [HttpGet]
        public Currency[] getcurrency()
        {
            string path = string.Format("{0}{1}", Environment.CurrentDirectory, "\\JsonData\\currencyCode.json");
            string jsonData = System.IO.File.ReadAllText(path);
            Currency[] curs = JsonConvert.DeserializeObject<Currency[]>(jsonData);

            return curs;
        }

        // POST <controller>/getcountries
        [HttpGet]
        public Country[] getcountries()
        {
            string path = string.Format("{0}{1}", Environment.CurrentDirectory, "\\JsonData\\country.json");
            string jsonData = System.IO.File.ReadAllText(path);
            Country[] cntry = JsonConvert.DeserializeObject<Country[]>(jsonData);

            return cntry;
        }
    }
}

using IdentityModel.Client;
using IdServerTestWebMVC.Models;
using IdServerTestWebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdServerTestWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenService _tokenService;

        public HomeController(ILogger<HomeController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Added package IdentityModel which is OpenID Connect & OAuth 2.0 client library        
        //created this
        public async Task<IActionResult> Weather() 
        {
            var data = new List<WeatherData>();
            using (var client = new HttpClient())
            {
                //get token and set it in header using some builtin methods from IdentityMoel Library Package.
                var tokenResponse = await _tokenService.GetToken("weatherapi.read");
                client.SetBearerToken(tokenResponse.AccessToken);

                //calling api for weather data 5445=44319
                var result = client.GetAsync("https://localhost:44319/WeatherForecast").Result;
                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<WeatherData>>(model);
                    return View(data);

                }
                else
                {
                    throw new Exception("Unable to Get Content");
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

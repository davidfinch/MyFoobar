using Microsoft.AspNetCore.Mvc;
using MyFoobar.Web.Interfaces;
using MyFoobar.Web.Models;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace MyFoobar.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService _weatherService;

        public HomeController(ILogger<HomeController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public Task<List<string>> Forecast()
        {
            return _weatherService.GetForecast("https://weather-broker-cdn.api.bbci.co.uk/en/forecast/rss/3day/2641181");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
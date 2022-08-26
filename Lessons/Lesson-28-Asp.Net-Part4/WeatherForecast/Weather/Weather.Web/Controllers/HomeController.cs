using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weather.Web.Models;
using Weather.Web.Services;

namespace Weather.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Random _random = new Random();

        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public HomeController(ILogger<HomeController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        // Model binding
        public async Task<IActionResult> Index(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return View();
            }

            var now = DateTime.Now;
            var weatherModel = new WeatherViewModel();

            var forecast = await _weatherForecastService.FindForecastAsync(search);

            weatherModel.Location = FindLocation(search);
            weatherModel.CurrentTemperature = _random.Next(-35, 35);
            weatherModel.WeatherType = (WeatherType)_random.Next(0, 2);

            weatherModel.DailyForecast = new[]
            {
                new DailyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    Time = now
                },
                new DailyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    Time = now.AddHours(1)
                },
                new DailyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    Time = now.AddHours(2)
                },
                new DailyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    Time = now.AddHours(3)
                },
                new DailyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    Time = now.AddHours(4)
                }
            };

            weatherModel.WeeklyForecast = new[]
            {
                new WeeklyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    DayOfWeek = now.DayOfWeek
                },
                new WeeklyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    DayOfWeek = now.AddDays(1).DayOfWeek
                },
                new WeeklyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    DayOfWeek = now.AddDays(1).DayOfWeek
                },
                new WeeklyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    DayOfWeek = now.AddDays(1).DayOfWeek
                },
                new WeeklyForecastViewModel
                {
                    Temperature = _random.Next(-35, 35),
                    DayOfWeek = now.AddDays(1).DayOfWeek
                }
            };

            return View("Weather", weatherModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string FindLocation(string search)
        {
            return "Минск";
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TMS.NET15.MVC.Models;

namespace TMS.NET15.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger/*, IDatabase db*/)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new IndexModel
            {
                Text = "Hello"
            };
            return View(model);
            //return View();
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
    }
}
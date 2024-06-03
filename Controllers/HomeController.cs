using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Template.Classes;
using Template.Models;

namespace Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomMemoryCache _memory;

        public HomeController(ILogger<HomeController> logger, ICustomMemoryCache memory)
        {
            _logger = logger;
            _memory = memory;
        }

        [Authorize(Roles = "Admin,Manager")]//give access to only Admin and Manager
        //[Authorize]//give access to all authenticated users(login required)
        public IActionResult Index()
        {
            if(_memory.Get<string>("key") == null)
            {
                _memory.Set("key", "From the Cache"); //basic cache example(will set default value for sliding and absolute expiry)

                // Set sliding expiration to 5 minutes and absolute expiration to 10 minutes
                //_memory.Set<string>("key", "From the Cache", TimeSpan.FromMinutes(5), DateTimeOffset.Now.AddMinutes(10));
                TempData["message"]= "Not From the cache";
            }
            else
            {
                TempData["message"] = _memory.Get<string>("key");
            }

            return View();
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

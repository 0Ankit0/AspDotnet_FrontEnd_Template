using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

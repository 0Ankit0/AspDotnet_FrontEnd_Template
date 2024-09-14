using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FRONTEND_TEMPLATE.Controllers
{
    public class DashboardController : Controller
    {
        [AutoValidateAntiforgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        // GET: DashboardController
        public ActionResult Index()
        {
            //To show name of the current user you can save the data in session and use it in view or import claim in role

            //string name = User?.FindFirst(ClaimTypes.Name)?.Value;
            //string role = User?.FindFirst(ClaimTypes.Role)?.Value;

            //if (name != null && role != null)
            //{
            //    HttpContext.Session.SetString("name", name);
            //    HttpContext.Session.SetString("role", role);
            return View();
            //}
            //else
            //{
            //	return RedirectToAction("Index", "Login");
            //}

        }

        // GET: DashboardController/Settings
        public ActionResult Settings()
        {
            return View();
        }

        // GET: DashboardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

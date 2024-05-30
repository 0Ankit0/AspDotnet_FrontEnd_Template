using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/loginUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult loginUser([FromForm] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.Email == "admin@gmail.com" && model.Password == "admin")
                    {

                    return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Invalid email or password.");
                        return View("Index",model);
                    }
                }
                else
                {
                    return View("Index", model);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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

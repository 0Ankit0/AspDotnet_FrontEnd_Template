using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Template.Models;

namespace Template.Controllers
{
    public class LoginController : Controller
    {


        // GET: LoginController
        public IActionResult Index(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                TempData["message"] = "You must be logged in to access this resource.";
            }

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
        public async Task<IActionResult> loginUser([FromForm] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.Email == "admin@gmail.com" && model.Password == "admin")
                    {
                        TempData["message"] = "Welcome, " + model.Email + "!";

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.Email),
                            new Claim(ClaimTypes.Role, "Admin")
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);
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

        // GET: LoginController/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Template.FRONTEND_TEMPLATE.Templates;
using Template.Models;

namespace Template.Controllers
{
    public class TemplateController : Controller
    {
        // GET: TemplateController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TemplateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TemplateController/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: TemplateController/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SelectColumnPage([FromForm] TemplateModel tm)
        {
            try
            {
                //if(tm.ConnectionString is null)
                //{
                //    ModelState.AddModelError("ConnectionString", "Invalid Connection String or connection String is empty.");
                //    return View("Index", tm);
                //}
                //if (tm.TableName is null)
                //{
                //    ModelState.AddModelError("TableName", "Invalid Table Name or Table Name is empty.");
                //    return View("Index", tm);
                //}
                
                SelectColumnTemplate selectColumn = new SelectColumnTemplate(tm);
                String selectColumnPage = selectColumn.TransformText();
                ViewBag.SelectColumnPage = selectColumnPage;
                 //System.IO.File.WriteAllText($"Views/Shared/_PartialTemplate.cshtml", selectColumnPage);
                return View("SelectColumnPage");
            }
            catch
            {
                return View("Index");
            }
        }
        [HttpGet]
        // GET: TemplateController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }
        [HttpPost]
          public ActionResult SelectColumns([FromForm] TemplateModel tm)
        {
            ModelTemplate model = new ModelTemplate(tm);
            String page = model.TransformText();
            System.IO.File.WriteAllText($"{tm.ModelPath}{tm.ControllerName}.cs", page);

            if (tm.ControllerType == "BackEnd")
            {

                BackendControllerTemplate backendController = new BackendControllerTemplate(tm);
                String backendControllerPage = backendController.TransformText();
                System.IO.File.WriteAllText($"{tm.ControllerPath}{tm.ControllerName}Controller.cs", backendControllerPage);
                ModelState.Clear();
                return View("Index");
            }
            else
            {

            ControllerTemplate controller = new ControllerTemplate(tm);
            String controllerPage = controller.TransformText();
            System.IO.File.WriteAllText($"{tm.ControllerPath}{tm.ControllerName}Controller.cs", controllerPage);

            ModelState.Clear();
            return View("Index");
            }
        }
       
        
        public ActionResult SelectColumnPage()
        {
            return View();
        }

        // POST: TemplateController/Edit/5
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

        // GET: TemplateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TemplateController/Delete/5
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

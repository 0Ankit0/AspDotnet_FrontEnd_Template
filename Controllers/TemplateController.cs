﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Template.Models;
using Template.Templates;

namespace Template.Controllers
{
    public class TemplateController : Controller
    {
        // GET: TemplateController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: TemplateController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TemplateController1/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: TemplateController1/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] TemplateModel tm)
        {
            try
            {
                ModelTemplate model = new ModelTemplate(tm);
                String page = model.TransformText();
                System.IO.File.WriteAllText($"Models/{tm.TableName}.cs", page);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: TemplateController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TemplateController1/Edit/5
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

        // GET: TemplateController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TemplateController1/Delete/5
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

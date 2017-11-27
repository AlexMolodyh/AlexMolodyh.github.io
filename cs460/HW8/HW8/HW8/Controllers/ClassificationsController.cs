using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class ClassificationsController : Controller
    {
        // GET: Classifications
        public ActionResult Index()
        {
            return View();
        }

        // GET: Classifications/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Classifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classifications/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Classifications/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Classifications/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Classifications/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Classifications/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

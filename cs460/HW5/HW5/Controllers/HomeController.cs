using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW5.DAL;
using HW5.Models;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        private CustomerContext db = new CustomerContext();

        public ActionResult Index() => View(db.Customers.ToList());

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW5.DAL;
using HW5.Models;

namespace HW5.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerContext db = new CustomerContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult CreateNewAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewAddress([Bind(Include = "CustomerNumber,FirstName,MiddleName,LastName,DOB,NewAddress,NewCity,NewState,NewZip,NewCounty,ChangeDate")] Customer customer)
        {
            if(ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("DisplayRequests");
            }

            return View();
        }
        
        public ActionResult DisplayRequests()
        {
            return View(db.Customers.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

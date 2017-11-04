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

/**
 * Author: Alex Molodyh
 * Date: 11/3/2017
 * Class: CS460
 * Assignment: HWK5
 **/

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
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

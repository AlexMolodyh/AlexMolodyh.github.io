using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW6.Models;
using System.Diagnostics;

namespace HW6.Controllers
{
    public class ProductController : Controller
    {
        private HW6DBContext db = new HW6DBContext();

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetProducts(string category, string subCategory)
        {
            Debug.WriteLine($"Category is: {category} and subcategory is: {subCategory}");

            return View("Index");
        }
    }
}

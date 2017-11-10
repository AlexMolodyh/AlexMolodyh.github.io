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

            DbSet<Product> items = db.Products;

            var productSet = db.Products.Join(db.ProductSubcategories.Where(ps => ps.Name == "Gloves"),
                p => p.ProductSubcategoryID,
                ps1 => ps1.ProductSubcategoryID,
                (p, ps1) => new { table = p });

            var subCater = db.ProductSubcategories.Where(ps => ps.Name == "Mountain Bikes").Select(ps2 => ps2.ProductSubcategoryID);
            int psIndex = subCater.First();

            var productIE = db.Products.Where(p => p.ProductSubcategoryID == psIndex);
            List<Product> productList = productIE.ToList<Product>();


            foreach(Product p in productList)
            {
                Debug.WriteLine($"Product Name is: {p.Name}");
            }


            return View("Index");
        }
    }
}

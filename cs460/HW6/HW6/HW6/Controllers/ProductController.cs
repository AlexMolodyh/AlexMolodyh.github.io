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
using PagedList;

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

        public ViewResult ProductsDisplay(string subCategory, int? page)
        {
            if (subCategory == null)
                subCategory = "Mountain Bikes";

            Debug.WriteLine($"Subcategory is: {subCategory}");
            ViewBag.SubCategory = subCategory;
           

            var subCater = db.ProductSubcategories.Where(ps => ps.Name == subCategory).Select(ps2 => ps2.ProductSubcategoryID);
            int psIndex = subCater.First();

            var productIE = db.Products.Where(p => p.ProductSubcategoryID == psIndex);
            List<Product> productList = productIE.ToList<Product>();


            //foreach(Product p in productList)
            //{
            //    Debug.WriteLine($"Product Name is: {p.Name} Photo name is: {p.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhotoFileName}");
            //}

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(productList.ToPagedList(pageNumber, pageSize));
        }
    }
}

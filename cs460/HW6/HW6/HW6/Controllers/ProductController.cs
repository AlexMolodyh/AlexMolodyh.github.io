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
        private static List<Product> productList;

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
            productList = productIE.ToList<Product>();


            //foreach(Product p in productList)
            //{
            //    Debug.WriteLine($"Product Name is: {p.Name} Photo name is: {p.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhotoFileName}");
            //}

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(productList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ProductInfo(int? pID)
        {
            return View(GetProduct(pID));
        }

        [HttpGet]
        public ActionResult WriteReview(int? pID)
        {
            ProductReview productReview = new ProductReview();
            productReview.ProductID = pID ?? 0;

            ViewBag.CurrentProductName = GetProduct(pID).Name;
            return View(productReview);
        }

        [HttpPost]
        public ActionResult WriteReview(ProductReview productReview)
        {
            Debug.WriteLine($"ProductReview: {productReview.ReviewerName}");
            
            productReview.ModifiedDate = DateTime.Now;
            productReview.ReviewDate = DateTime.Now;

            db.Products.Select(p => p.ProductReviews).First().Add(productReview);
            db.ProductReviews.Add(productReview);
            db.SaveChanges();
            return View("ThankYou", productReview);
        }

        public ActionResult ThankYou(ProductReview productReview)
        {
            return View(productReview);
        }

        public Product GetProduct(int? pID)
        {
            int productID = pID ?? 1;
            return db.Products.Where(p => p.ProductID == productID).First();
        }
    }
}

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
    /// <summary>
    /// ProductController manages populating lists of products and modifying the database.
    /// </summary>
    public class ProductController : Controller
    {
        private HW6DBContext db = new HW6DBContext();
        private static List<Product> productList;

        /// <summary>
        /// ProductDisplay retrieves a list of Products from the database by using a 
        /// subcategory name.
        /// </summary>
        /// <param name="subCategory">A string that represents the subcategory of products
        /// that should be retrieved.</param>
        /// <param name="page">The amount of items that you want to display in a pagedList</param>
        /// <returns>A list containing Products the size of the page number provided.</returns>
        public ViewResult ProductsDisplay(string subCategory, int? page)
        {
            if (subCategory == null)
                subCategory = "Mountain Bikes";
            
            ViewBag.SubCategory = subCategory;

            var subCater = db.ProductSubcategories.Where(ps => ps.Name == subCategory).Select(ps2 => ps2.ProductSubcategoryID);
            int psIndex = subCater.First();

            var productIE = db.Products.Where(p => p.ProductSubcategoryID == psIndex);
            productList = productIE.ToList<Product>();

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(productList.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Retrieves the information for a product.
        /// </summary>
        /// <param name="pID">The ProductID number of the product to retrieve</param>
        /// <returns>Returns a Product object.</returns>
        public ActionResult ProductInfo(int? pID)
        {
            return View(GetProduct(pID));
        }

        /// <summary>
        /// Prepares a ProductReview object to capture the users review of an item.
        /// </summary>
        /// <param name="pID">The Product that the customer wants to add a review to.</param>
        /// <returns>A ProductReview object.</returns>
        [HttpGet]
        public ActionResult WriteReview(int? pID)
        {
            ProductReview productReview = new ProductReview();
            productReview.ProductID = pID ?? 0;

            ViewBag.CurrentProductName = GetProduct(pID).Name;
            return View(productReview);
        }

        /// <summary>
        /// WriteReview takes in a ProductReview object and saves it to the database.
        /// </summary>
        /// <param name="productReview">A ProductReview that needs to be saved 
        /// to the database.</param>
        /// <returns>A view thanking the user for the review or an error page if the user
        /// input bad data.</returns>
        [HttpPost]
        public ActionResult WriteReview(ProductReview productReview)
        {
            try
            {
                productReview.ModifiedDate = DateTime.Now;
                productReview.ReviewDate = DateTime.Now;

                db.Products.Select(p => p.ProductReviews).First().Add(productReview);
                db.ProductReviews.Add(productReview);
                db.SaveChanges();
                return View("ThankYou", productReview);
            }
            catch(Exception e)
            {
                return View("BadInput", productReview.ReviewerName);
            }
        }


        /// <summary>
        /// Displays a thank you page to the user
        /// </summary>
        /// <param name="productReview">A ProductReview object</param>
        /// <returns>A View thanking the user for their review.</returns>
        public ActionResult ThankYou(ProductReview productReview)
        {
            return View(productReview);
        }

        public ActionResult BadInput(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        public Product GetProduct(int? pID)
        {
            int productID = pID ?? 1;
            return db.Products.Where(p => p.ProductID == productID).First();
        }
    }
}

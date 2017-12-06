using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.DAL;
using Final.Model;

namespace Final.Controllers
{
    public class SellersController : Controller
    {
        private finalDBContext db = new finalDBContext();

        // GET: Sellers
        public ActionResult Index()
        {
            return View(db.Sellers.ToList());
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

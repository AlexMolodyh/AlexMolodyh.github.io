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
using HW8.Models;

namespace Final.Controllers
{
    public class BidsController : Controller
    {
        private finalDBContext db = new finalDBContext();

        // GET: Bids
        public ActionResult Index()
        {
            var bids = db.Bids.Include(b => b.Buyer);
            return View(bids.ToList());
        }

        // GET: Bids/Create
        public ActionResult Create()
        {
            ViewBag.BuyerName = new SelectList(db.Buyers, "BuyerName", "BuyerName");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,BuyerName,Price,TimeStamp")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                bid.TimeStamp = DateTime.Now;
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerName = new SelectList(db.Buyers, "BuyerName", "BuyerName", bid.BuyerName);
            return View(bid);
        }


        public JsonResult GetBids(int? itemID)
        {
            var itemList = db.Bids.Where(b => b.ItemID == itemID).ToList();
            return Json(itemList, JsonRequestBehavior.AllowGet);
        }

        ///*populates a list of of artwork names and genres from a Genre list.*/
        //private BidList ConvertBids(List<Bid> iList)
        //{
        //    List<BidList> tempList = new List<BidList>();
        //    foreach (var aw in iList)
        //    {
        //        tempList.
        //    }
        //    return tempList;
        //}

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

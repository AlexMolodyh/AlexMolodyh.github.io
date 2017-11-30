using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.DAL;
using HW8.Model;

namespace HW8.Controllers
{
    public class ArtWorksController : Controller
    {
        private ArtDBContext db = new ArtDBContext();

        
        public ActionResult Index()
        {
            var artWorks = db.ArtWorks.Include(a => a.Artist1);
            return View(artWorks.ToList());
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

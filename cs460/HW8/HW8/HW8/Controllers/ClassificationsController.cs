using System.Data.Entity;
using HW8.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class ClassificationsController : Controller
    {
        public ArtDBContext db = new ArtDBContext();

        
        public ActionResult Index()
        {
            var artWorks = db.ArtWorks.Include(a => a.Artist1);
            return View(artWorks.ToList());
        }
    }
}

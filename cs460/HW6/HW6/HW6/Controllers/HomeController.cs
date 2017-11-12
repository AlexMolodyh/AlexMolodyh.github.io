using HW6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        HW6DBContext db = new HW6DBContext();
        static List<ProductPhoto> photoList;
        static List<int> photoIDs;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            var photoVarList = db.ProductPhotoes.ToList();
            var photoVarIDs = db.ProductPhotoes.Select(pp => pp.ProductPhotoID);
            photoList = photoVarList.ToList<ProductPhoto>();
            photoIDs = photoVarIDs.ToList<int>();

            return View(photoList);
        }
    }
}
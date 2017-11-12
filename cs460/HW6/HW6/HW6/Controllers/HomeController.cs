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

        public ActionResult Index()
        {

            var photoVarList = db.ProductPhotoes.ToList();
            var photoVarIDs = db.ProductPhotoes.Select(pp => pp.ProductPhotoID);
            photoList = photoVarList.ToList<ProductPhoto>();
            photoIDs = photoVarIDs.ToList<int>();

            Debug.WriteLine($"random num is: {photoList.First().GetRandomInt(photoList.Count)}");

            //Debug.WriteLine(String.Format("data:image/png;base64,{0}", Convert.ToBase64String(photoList.First().LargePhoto)));

            return View(photoList);
        }

        [HttpPost]
        public byte[] NextImage()
        {
            byte[] img = null;
            Random rand = new Random();
            int newImgIndex = rand.Next(0, photoIDs.Count);

            img = photoList[newImgIndex].LargePhoto;

            return img;
        }
    }
}
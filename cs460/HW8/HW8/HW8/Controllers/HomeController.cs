using HW8.DAL;
using HW8.Model;
using HW8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
        public ArtDBContext db = new ArtDBContext();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Retrieves a list of artwork based on the genre selected.
        /// </summary>
        /// <param name="genre">The genre of artwork to query</param>
        /// <returns>A Json object that is a list of artwork names and genres.</returns>
        public JsonResult GenreArtWork(string genre)
        {
            var genreList = db.Genres.Where(g => g.GenreName == genre).ToList().First();
            ArtWorkList awl = new ArtWorkList();
            awl.ArtList = ConvertArtWork(genreList);
            awl.GenreName = genreList.GenreName;
            awl.Size = genreList.ArtWorks.Count;

            return Json(awl, JsonRequestBehavior.AllowGet);
        }

        /*populates a list of of artwork names and genres from a Genre list.*/
        private List<string> ConvertArtWork(Genre gList)
        {
            List<string> tempList = new List<string>();
            foreach(var aw in gList.ArtWorks)
            {
                tempList.Add(aw.ArtWorkTitle);
            }
            return tempList;
        }
    }
}
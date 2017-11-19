using HW7.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetJson(string searchArea, string searchParams)
        {
            Debug.WriteLine($"searchArea: {searchArea} searchParams: {searchParams}");

            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyKey"];
            string url2 = "api.giphy.com/v1/gifs/search?api_key=tMVARbZrhB0UhISU7uAiWIBiUKqUNcuf&q=cheeseburgers";
            string url = $"http://api.giphy.com{searchArea}?api_key={apiKey}&q={searchParams}";
            Debug.WriteLine($"Url is: {url}");

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";
            httpRequest.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            var result = sr.ReadToEnd();
            Debug.WriteLine("Result is: " + result);
    
            GiphyObj giphyObjs = JsonConvert.DeserializeObject<GiphyObj>(result, Converter.Settings);
            
            Debug.WriteLine("The data is: " + giphyObjs.Data[0].Images.OriginalStill.Url);
            Debug.WriteLine($"Data count is: {giphyObjs.Data.Count}");
            GifList gl = GetGifs(giphyObjs);

            return Json(gl, JsonRequestBehavior.AllowGet);
        }

        private GifList GetGifs(GiphyObj giphyObj)
        {
            GifList gifList = new GifList();
            int size = giphyObj.Data.Count;

            List<Gif> gifs = new List<Gif>(size);

            for (int i = 0; i < giphyObj.Data.Count; i++)
            {
                Gif myGif = new Gif();
                myGif.Url = giphyObj.Data[i].Images.Original.Url;
                myGif.Username = (giphyObj.Data[i].User != null) ? giphyObj.Data[i].User.Username : null;
                gifs.Add(myGif);
            }
            gifList.Gifs = gifs;
            gifList.Size = gifList.Gifs.Count;
            return gifList;
        }
    }

    public static class Serialize
    {
        public static string ToJson(this GiphyObj self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }


    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
using HW7.DAL;
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

namespace HW7.Controllers
{
    public class GiphyController : Controller
    {
        GifRequestContext db = new GifRequestContext();

        [HttpGet]
        public JsonResult GetJsonGifs(string searchArea, string searchParams, string rating)
        {
            //Get the 
            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string userAgent = Request.Headers["User-Agent"].ToString();

            if(string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];
                for(int i = 0; i < Request.ServerVariables.Count; i++)
                {
                    Debug.WriteLine($"Address: {Request.ServerVariables[i]}");
                }
            }

            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyKey"];
            string url = $"http://api.giphy.com{searchArea}?api_key={apiKey}&q={searchParams}";
            Debug.WriteLine($"Url is: {url}");
            GifList gl = new GifList();

            try
            {
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
                gl = GetGifs(giphyObjs, rating);
            }
            catch (Exception e){}


<<<<<<< HEAD
            GifRequest giphyRequest = new GifRequest()
            {
                IPAddress = ipAddress,
                BrowserType = userAgent,
                RequestDate = DateTime.Now,
                SearchType = searchArea,
                Rating = rating,
                KeyWord = searchParams
            };
            LogRequest(giphyRequest);//Log user request
=======
            Debug.WriteLine("The data is: " + giphyObjs.Data[0].Images.OriginalStill.Url);
            Debug.WriteLine($"Data count is: {giphyObjs.Data.Count}");
            GifList gl = GetGifs(giphyObjs, rating);
>>>>>>> HW7ul

            return Json(gl, JsonRequestBehavior.AllowGet);
        }

        private GifList GetGifs(GiphyObj giphyObj, string rating)
        {
            GifList gifList = new GifList();
            int size = giphyObj.Data.Count;

            List<Gif> gifs = new List<Gif>(size);

            Debug.WriteLine($"Rating: {rating}");

            for (int i = 0; i < giphyObj.Data.Count; i++)
            {
                if (rating.Equals("all"))
                {
                    gifs = AddGif(giphyObj, i, gifs);
                }
                else
                {
                    if(rating.Equals(giphyObj.Data[i].Rating))
                    {
                        gifs = AddGif(giphyObj, i, gifs);
                    }
                }
            }
            gifList.Gifs = gifs;
            gifList.Size = gifList.Gifs.Count;
            return gifList;
        }

        private List<Gif> AddGif(GiphyObj giphyObj, int i, List<Gif> gifs)
        {
            Gif myGif = new Gif();
            myGif.Url = giphyObj.Data[i].Images.Original.Url;
            myGif.Username = (giphyObj.Data[i].User != null) ? giphyObj.Data[i].User.Username : null;
            gifs.Add(myGif);

            return gifs;
        }
<<<<<<< HEAD

        private void LogRequest(GifRequest gif)
        {
            try
            {
                db.GifRequests.Add(gif);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error is: {e.StackTrace}");
            }
        }
=======
>>>>>>> HW7ul
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
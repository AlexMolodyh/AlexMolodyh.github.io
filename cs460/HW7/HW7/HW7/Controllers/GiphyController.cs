/*
 * Author: Alexander Molodyh
 * Date: 11/19/2017
 * Class: CS460
 * Assignment: HW7
 */


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
    /// <summary>
    /// GiphyController retrieves a Gifs from Giphy.com and sends them back to the requester.
    /// </summary>
    public class GiphyController : Controller
    {
        GifRequestContext db = new GifRequestContext();

        /// <summary>
        /// Sends a GET request to giphy.com and recieves a Json object of gifs.
        /// The gifs are then filtered and sent back to the client.
        /// </summary>
        /// <param name="searchArea">The area to search for gifs in such as: search, trending, and random</param>
        /// <param name="searchParams">Something to search for in the search area. Ex: cheeseburgers, dragons, cars..</param>
        /// <param name="rating">A rating to filter the gif output with such as: Rated G, PG, PG-13, or All</param>
        /// <returns>A Json object that contains a list of gif objects</returns>
        [HttpGet]
        public JsonResult GetJsonGifs(string searchArea, string searchParams, string rating)
        {
            //Get the IP address and browser user agent for logging.
            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string userAgent = Request.Headers["User-Agent"].ToString();
            if(string.IsNullOrEmpty(ipAddress))
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];

            //Get api key and build the GET request header.
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyKey"];
            string url = $"http://api.giphy.com{searchArea}?api_key={apiKey}&q={searchParams}";
            Debug.WriteLine($"Url is: {url}");
            GifList gl = new GifList();
            GiphyObj giphyObjs = null;

            /*Try to deserialize the json data into C# objects*/
            try
            {
                //Send request to Giphy.com
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "GET";
                httpRequest.ContentType = "application/json";

                //Handle response
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                var result = sr.ReadToEnd();
                Debug.WriteLine("Result is: " + result);

                giphyObjs = JsonConvert.DeserializeObject<GiphyObj>(result, Converter.Settings);
            }
            catch (Exception e){ Debug.WriteLine(e.StackTrace); }

            gl = GetGifs(gl, giphyObjs, rating);
            LogRequest(ipAddress, userAgent, searchArea, searchParams, rating);//Log user request

            return Json(gl, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Filters the gifs based on the client rating selection.
        /// </summary>
        /// <param name="gifList">A GifList to populate with Gifs</param>
        /// <param name="giphyObj">The GiphyObj containing Json gifs that were serialized</param>
        /// <param name="rating">The rating to filter the gifs with</param>
        /// <returns></returns>
        private GifList GetGifs(GifList gifList, GiphyObj giphyObj, string rating)
        {
            if (giphyObj == null)
                return null;

            int size = giphyObj.Data.Count;
            List<Gif> gifs = new List<Gif>(size);

            //filters the gifs
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

            //add the gif list to the GifList object
            gifList.Gifs = gifs;
            gifList.Size = gifList.Gifs.Count;
            return gifList;
        }

        //Adds a gif to the list of gifs
        private List<Gif> AddGif(GiphyObj giphyObj, int i, List<Gif> gifs)
        {
            Gif myGif = new Gif();
            myGif.Url = giphyObj.Data[i].Images.Original.Url;
            myGif.Username = (giphyObj.Data[i].User != null) ? giphyObj.Data[i].User.Username : null;
            gifs.Add(myGif);

            return gifs;
        }

        //Inserts a client request into the database.
        private void LogRequest(string ipAddress, string userAgent, string searchArea, string searchParams, string rating)
        {
            GifRequest giphyRequest = new GifRequest()
            {
                IPAddress = ipAddress,
                BrowserType = userAgent,
                RequestDate = DateTime.Now,
                SearchType = searchArea,
                Rating = rating,
                KeyWord = searchParams
            };

            try
            {
                db.GifRequests.Add(giphyRequest);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error is: {e.StackTrace}");
            }
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
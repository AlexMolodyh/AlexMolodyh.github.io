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
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyKey"];
            string url = "api.giphy.com/v1/gifs/trending?api_key=" + apiKey;

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("http://api.giphy.com/v1/gifs/trending?api_key=" + apiKey);
            httpRequest.Method = "GET";
            httpRequest.ContentType = "application/json";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            //Stream stream = httpRequest.GetRequestStream();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            var result = sr.ReadToEnd();
            Debug.WriteLine("Result is: " + result);

            GettingStarted giphyObjs =  JsonConvert.DeserializeObject<GettingStarted>(result, Converter.Settings);

            Debug.WriteLine("The data is: " + giphyObjs.Data.First().Type);

            Debug.WriteLine("Api key is: " + apiKey);
            return View();
        }
        

    }

    public static class Serialize
    {
        public static string ToJson(this GettingStarted self) => JsonConvert.SerializeObject(self, Converter.Settings);
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
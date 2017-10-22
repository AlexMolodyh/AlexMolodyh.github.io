using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PageOne()
        {
            string temperature = Request.Form["temperatue"];
            string temp_type = Request.Form["temp_type"];
            double tempToConvert = 0.0;
            double converted = 0.0;

            ViewBag.converted = temperature;
            Console.WriteLine("Hello " + temperature);


            if (Double.TryParse(temperature, out tempToConvert))
            {
                if (temp_type.Equals("F"))
                    converted = (((tempToConvert - 32) * 5) / 9);
                else if (temp_type.Equals("C"))
                    converted = (((tempToConvert * 9) / 5) + 32);
                else
                    converted = 0.0;

                ViewBag.converted = converted;
            }


            return View();
        }

        public ActionResult PageTwo()
        {
            return View();
        }

        public ActionResult PageThree()
        {
            return View();
        }
    }
}








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
            string temperature = Request.Form["temperature"];
            string temp_type = Request.Form["temp_type"];
            double tempToConvert = 0.0;


            if (Double.TryParse(temperature, out tempToConvert))
            {
                if (temp_type.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                    ViewBag.converted = (((tempToConvert - 32) * 5) / 9);
                else if (temp_type.Equals("F", StringComparison.InvariantCultureIgnoreCase))
                    ViewBag.converted = (((tempToConvert * 9) / 5) + 32);
                else
                    ViewBag.converted = "Incorrect Input!";
            }
            else if(temperature != null && temp_type != null)
            {
                ViewBag.converted = "Incorrect Input!";
            }


            return View();
        }

        public ActionResult PageTwo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PageTwo(FormCollection form)
        {
            ValueProviderResult distance = form.GetValue("distance");
            ValueProviderResult dist_type = form.GetValue("dist_type");
            double distToConvert = 0.0;


            if (Double.TryParse(distance.AttemptedValue, out distToConvert))
            {
                if (dist_type.AttemptedValue.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                    ViewBag.converted = distToConvert * .62;
                else if (dist_type.AttemptedValue.Equals("K", StringComparison.InvariantCultureIgnoreCase))
                    ViewBag.converted = distToConvert * 1.609;
                else
                    ViewBag.converted = "Incorrect Input!";
            }
            else if (distance != null && dist_type != null)
            {
                ViewBag.converted = "Incorrect Input!";
            }

            return View();
        }

        public ActionResult PageThree()
        {
            return View();
        }
    }
}








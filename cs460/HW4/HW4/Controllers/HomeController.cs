﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
            string temperature = Request.Form["temperature"];//temperature entered
            string temp_type = Request.Form["temp_type"];//the type of temperature to convert to
            double tempToConvert = 0.0;//the converted temperature entered so we can do computations


            if (Double.TryParse(temperature, out tempToConvert))
            {
                if (temp_type.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                    ViewBag.converted = (((tempToConvert - 32) * 5) / 9);//converted to celsius
                else if (temp_type.Equals("F", StringComparison.InvariantCultureIgnoreCase))
                    ViewBag.converted = (((tempToConvert * 9) / 5) + 32);//converted to fahrenheit
                else
                    ViewBag.converted = "Incorrect Input!";//incorrect temperature type was entered
            }
            else if(temperature != null && temp_type != null)//incorrect distance was entered
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
            ValueProviderResult distance = form.GetValue("distance");//distance entered
            ValueProviderResult distType = form.GetValue("dist_type");//miles or kilometers to convert to
            double distToConvert = 0.0;//the converted distance entered so we can do computations


            if (Double.TryParse(distance.AttemptedValue, out distToConvert))
            {
                ViewBag.distance = distance.AttemptedValue;

                //converting into miles
                if (distType.AttemptedValue.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                {
                    ViewBag.convertFrom = "Kilometers";
                    ViewBag.convertTo = "Miles";
                    ViewBag.converted = distToConvert * .62;
                }
                else if (distType.AttemptedValue.Equals("K", StringComparison.InvariantCultureIgnoreCase))
                {
                    //converting into kilometers
                    ViewBag.convertFrom = "Miles";
                    ViewBag.convertTo = "Kilometers";
                    ViewBag.converted = distToConvert * 1.609;
                }
                else
                {
                    ViewBag.error = "Incorrect Input!!";//wrong input for conversion type
                }
            }
            else if (distance != null && distType != null)
            {
                //incorrect distance was entered, as in not a number
                ViewBag.converted = "Incorrect Input!";
            }

            return View();
        }

        [HttpGet]
        public ActionResult PageThree()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PageThree(int? loanAmount, double? interestRate, int? months)
        {
            double percentage = (interestRate / 100) / 12 ?? 0;//convert percentage to calculate for months

            double monthsAsDouble = months * 1.0 ?? 1;//convert months into a double for Pow method

            //we use this calculation twice so I just made it for simplicity
            double partOfD = Math.Pow((1 + percentage), monthsAsDouble);

            double d = ((partOfD - 1) / (percentage * partOfD));//total calculation that we divide total amount by

            double montlyPyment = loanAmount / d ?? 0;//total montly payment

            double paymentSum = montlyPyment * monthsAsDouble;//loan amount plus interest 

            ViewBag.totalMonths = months ?? 0;
            ViewBag.monthPayment = $"{montlyPyment:C2}";
            ViewBag.paySum = $"{paymentSum:C2}";
            ViewBag.totalInterest = $"{paymentSum - monthsAsDouble:C2}";
            

            return View("PageThreePost");
        }
    }
}








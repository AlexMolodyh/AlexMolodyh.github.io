using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW5.DAL;
using HW5.Models;

/**
 * Author: Alex Molodyh
 * Date: 11/3/2017
 * Class: CS460
 * Assignment: HWK5
 **/

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        private CustomerContext db = new CustomerContext();

        public ActionResult Index() => View();
    }
}
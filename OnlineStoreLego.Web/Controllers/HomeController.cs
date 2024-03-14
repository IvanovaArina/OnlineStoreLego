using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStoreLego.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
            //add UserBO in argument
        {
            return View();

        }
        public ActionResult About()
        {
            return View();

        }
        public ActionResult Contact()
        {
            return View();

        }
        public ActionResult ShopListing()
        {
            return View();

        }
        public ActionResult LogIn()
        {
            return View();
        }



    }
}
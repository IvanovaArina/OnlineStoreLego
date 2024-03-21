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

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult BlogDetail()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Wishlist()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ProductDetail()
        {
            return View();
        }

    }
}
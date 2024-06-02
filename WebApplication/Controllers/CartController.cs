using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CartController : Controller
    {
        //// GET: Cart
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        public ActionResult AddToCart (int productId, int userId)
        {
            return View();
        }

    }
}
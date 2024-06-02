using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class WishlistController : Controller
    {
        // GET: Wishlist
        public ActionResult Wishlist()
        {
            return View("Wishlist");
        }

        public ActionResult AddToWishlist()
        {
            return View();
        }
    }
}
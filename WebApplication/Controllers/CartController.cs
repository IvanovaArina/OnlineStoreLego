using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core;
using WebApplication.BL.Core.APIs;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CartController : Controller
    {
        public ActionResult AddToCart(int productId, int userId)
        {
            CartApi cartApi = new CartApi();
            cartApi.AddToCartInDb(productId, userId);
            return RedirectToAction("ShopListing", "HomeUser");
        }

        [HttpPost]
        public void IncreaseCartCount(int productId, int userId)
        {
        }

        [HttpPost]
        public void DecreaseCartCount(int productId, int userId)
        {
        }

    }
}
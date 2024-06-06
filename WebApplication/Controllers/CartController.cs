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
        public ActionResult IncreaseCartCount(int productId, int cartId)
        {
            CartApi cartApi=new CartApi();  
            cartApi.IncreaseCartCount (productId, cartId);
            return RedirectToAction("Cart", "HomeUser");
        }

        [HttpPost]
        public ActionResult DecreaseCartCount(int productId, int cartId)
        {
            CartApi cartApi = new CartApi();
            cartApi.DecreaseCartCount(productId, cartId);
            return RedirectToAction("Cart", "HomeUser");
        }     
        
        public ActionResult DeleteProductFromCart(int productId)
        {
            CartApi cartApi = new CartApi();
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            cartApi.DeleteProductFromCart(productId, model.CartId);
            return RedirectToAction("Cart", "HomeUser");
        }

    }
}
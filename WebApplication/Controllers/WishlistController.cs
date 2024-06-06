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
    public class WishlistController : Controller
    {    

       public ActionResult AddToWishlist(int productId, int userId)
        {
            WishlistApi wishlistApi = new WishlistApi();
            wishlistApi.AddToWishlistInDb(productId, userId);
            return RedirectToAction("ShopListing", "HomeUser");
        }

        public ActionResult DeleteProductFromWishlist(int productId)
        {
            WishlistApi wishlistApi = new WishlistApi();
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            wishlistApi.DeleteProductFromWishlist(productId, model.WishlistId);
            return RedirectToAction("Wishlist", "HomeUser");
        }


    }
}
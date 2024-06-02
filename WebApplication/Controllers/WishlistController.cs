using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class WishlistController : Controller
    {
        WishlistApi wishlistApi = new WishlistApi();

        //// GET: Wishlist
        //public ActionResult Wishlist()
        //{
        //    return View("Wishlist");
        //}

        public ActionResult AddToWishlist(int productId, int userId)
        {
            wishlistApi.AddToWishlistInDb(productId, userId);
            UserDataModel userDataModel = new UserDataModel();
            UserApi userApi = new UserApi();
            userDataModel = userDataModel.moveDataFromDTOToModel(userApi.getUserDTObyId(userId));
            return RedirectToAction("Wishlist", "HomeUser", userDataModel);
        }
    }
}
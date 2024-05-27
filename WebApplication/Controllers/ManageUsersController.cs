using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ManageUsersController : Controller
    {
        [HttpGet]
        public ActionResult ManageUsers ()
        {
            return View();
        }





        public ActionResult AdminAccount()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }

        public ActionResult ManageContent()
        {
            return RedirectToAction("ManageContent", "Admin");
        }

        public ActionResult ManageProducts(ProductModel productModel)
        {
            return RedirectToAction("ManageProducts", "Admin", productModel);
        }
        public ActionResult ManageReview(ReviewModel reviewModel)
        {
            return RedirectToAction("ManageReview", "Admin", reviewModel);
        }

        public ActionResult ViewOrders()
        {
            return RedirectToAction("ViewOrders", "Admin");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        ArticleDataModel currentArticleDataModel = new ArticleDataModel();
        public ActionResult AdminAccount()
        {
            return View();
        }

        public ActionResult ManageUsers()
        {
            return RedirectToAction("ManageUsers", "ManageUsers");
        }

        public ActionResult ManageProducts(ProductModel productModel)
        {
            return View(productModel);
        }
        public ActionResult ManageReview(ReviewModel reviewModel)
        {
            return View(reviewModel);
        }

        [HttpGet]
        public ActionResult ManageContent(ArticleDataModel articleDataModel)
        {
            return RedirectToAction("ManageContent", "ManageContent");
        }

        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult CreateProduct()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        [HttpGet]
        public ActionResult Index(ReviewModel reviewModel)
        {
            return View(reviewModel);
        }

        [HttpPost]
        public ActionResult DeleteReview(ReviewModel reviewModel)
        {
            ReviewApi reviewApi = new ReviewApi();
            reviewApi.deleteReview(reviewModel.ReviewId);

            return View("Index", reviewModel);
        }

        [HttpPost]
        public ActionResult AcceptReview(ReviewModel reviewModel)
        {
            ReviewApi reviewApi = new ReviewApi();
            reviewApi.changeStatusOnApproved(reviewModel.ReviewId);
            return View("Index", reviewModel);
        }

        public ActionResult AdminAccount()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }

        public ActionResult ManageUsers()
        {
            return RedirectToAction("ManageUsers", "Admin");
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
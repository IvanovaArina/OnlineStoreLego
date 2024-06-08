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
        //[HttpGet]
        //public ActionResult Index(ReviewModel reviewModel)
        //{
        //    return View(reviewModel);
        //}

        private readonly ReviewApi _reviewApi = new ReviewApi();

        [HttpGet]
        public ActionResult Index()
        {
            var reviewModel = new ReviewModel();
            ViewBag.PendingReviews = reviewModel.GetPendingReviews();
            ViewBag.ApprovedReviews = reviewModel.GetApprovedReviews();
            return View(reviewModel);
        }

        [HttpPost]
        public ActionResult AcceptReview(int reviewId)
        {
            _reviewApi.AcceptReview(reviewId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DenyReview(int reviewId)
        {
            _reviewApi.DenyReview(reviewId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteReview(int reviewId)
        {
            _reviewApi.deleteReview(reviewId);
            return RedirectToAction("Index");
        }

        public ActionResult AdminAccount()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }

        public ActionResult ManageUsers()
        {
            return RedirectToAction("ManageUsers", "Admin");
        }

        public ActionResult ManageProduct(ProductModel productModel)
        {
            return RedirectToAction("ManageProduct", "Admin", productModel);
        }
        public ActionResult ManageReview(ReviewModel reviewModel)
        {
            return RedirectToAction("ManageReview", "Admin", reviewModel);
        }

        public ActionResult ManageContent(ReviewModel reviewModel)
        {
            return RedirectToAction("ManageContent", "ManageContent", reviewModel);
        }

        public ActionResult ViewOrders()
        {
            return RedirectToAction("ViewOrders", "Admin");
        }

        public ActionResult ManageContent()
        {
            return RedirectToAction("ManageContent", "ManageContent");
        }

    }
}
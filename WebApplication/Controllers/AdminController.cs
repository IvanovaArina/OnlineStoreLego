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
        // GET: Admin
        public ActionResult AdminAccount()
        {
            return View();
        }

        public ActionResult ManageUsers()
        {
            return View();
        }

        public ActionResult ManageProducts(ProductModel productModel)
        {
            return View(productModel);
        }
        public ActionResult ManageReview()
        {
            return View();
        }
        public ActionResult ManageContent()
        {
            return View();
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
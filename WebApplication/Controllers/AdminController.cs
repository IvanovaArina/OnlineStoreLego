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

        public ActionResult ManageProducts()
        {
            return View();
        }
        public ActionResult ManageReview()
        {
            return View();
        }
        public ActionResult ManageContent()
        {
            ArticleDataModel articleDataModel = new ArticleDataModel();
            return View(articleDataModel);
        }

        public ActionResult ManageContentShow(ArticleDataModel articleDataModel)
        {
            return View(articleDataModel);
        }



        public ActionResult ViewOrders()
        {
            return View();
        }
    }
}
﻿using System;
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

        [HttpPost]
        public ActionResult ManageContent(ArticleDataModel articleDataModel)
        {
            return RedirectToAction("Index", "ManageContent");
        }

        public ActionResult ViewOrders()
        {
            return View();
        }
    }
}
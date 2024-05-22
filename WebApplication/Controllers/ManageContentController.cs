using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ManageContentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageContent(ArticleDataModel articleDataModel)
        {
            return View(articleDataModel);
        }

        public ActionResult AddArticle(ArticleDataModel articleDataModel)
        {
            return View(articleDataModel);
        }

        public ActionResult EditArticle(ArticleDataModel articleDataModel)
        {
            return View(/*"ManageContent",*/ articleDataModel);
        } 
        
        public ActionResult DeleteArticle (ArticleDataModel articleDataModel)
        {
            return View(/*"ManageContent",*/ articleDataModel);
        }





    }
}
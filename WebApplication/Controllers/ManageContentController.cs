using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ManageContentController : Controller
    {
        
        [HttpGet]
        public ActionResult ManageContent(ArticleDataModel articleDataModel)
        {
            return View(articleDataModel);
        }

        [HttpPost]
        public ActionResult AddArticleAction(ArticleDataModel articleDataModel)
        {
            ArticleDTO articleDTO = articleDataModel.moveDataFromModelToDTO();
            ArticleApi articleApi = new ArticleApi();

            //обработать Base Answer
            articleApi.addArticleToDb(articleDTO);

            return RedirectToAction("ManageContent", articleDataModel);

        }

        [HttpPost]
        public ActionResult AddArticle(ArticleDataModel articleDataModel)
        {
            return View(articleDataModel);
        }

        [HttpPost]
        public ActionResult EditArticle(ArticleDataModel articleDataModel)
        {
            return View(articleDataModel);
        }

        [HttpPost]
        public ActionResult DeleteArticle (ArticleDataModel articleDataModel)
        {
            return View(articleDataModel);
        } 
        
        [HttpPost]
        public ActionResult CancelAdd (ArticleDataModel articleDataModel)
        {
            return View("ManageContent", articleDataModel);
        }





    }
}
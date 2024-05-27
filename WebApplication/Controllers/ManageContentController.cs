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

      
        [HttpGet]
        public ActionResult AddArticle(ArticleDataModel articleDataModel)
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
        public ActionResult EditArticle(ArticleDataModel articleDataModel)
        {
            ArticleApi articleApi = new ArticleApi();

            if (articleApi.checkIfArticleNumberExistsByNumber(articleDataModel.ArticleNumber))
            {
                ArticleDTO articleDTO = articleApi.getArticleDTObyNumber(articleDataModel.ArticleNumber);
               

                return View(articleDataModel.moveDataFromDTOToModel(articleDTO));
            }
            else
            {
                return RedirectToAction("AddArticle", "ManageContent", articleDataModel);
            }

        }

        [HttpPost]
        public ActionResult EditArticleAction(ArticleDataModel articleDataModel)
        {

            ArticleDTO articleDTO = articleDataModel.moveDataFromModelToDTO();
            ArticleApi articleApi = new ArticleApi();

            //обработать Base Answer
            articleApi.editArticleInDb(articleDTO);


            return View("ManageContent", articleDataModel);
        }

        [HttpPost]
        public ActionResult DeleteArticle (ArticleDataModel articleDataModel)
        {
            ArticleApi articleApi = new ArticleApi();
            articleApi.deleteArticle(articleDataModel.ArticleNumber);

            return View("ManageContent", articleDataModel);
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
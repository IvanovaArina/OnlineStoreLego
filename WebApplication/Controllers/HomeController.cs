using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL;
using WebApplication.BL.DBModel;
using WebApplication.BL.Interfaces;
using WebApplication.Domain.Entities.User;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Models;
using AutoMapper;
using System.Web.Security;
using System.Web.UI.WebControls;

using System.Threading.Tasks;
using WebApplication.Domain.Entities.Enums;

namespace OnlineStoreLego.Web.Controllers
{
    public class HomeController : Controller
    {

        private NewArticleContext db = new NewArticleContext();
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult About()
        {
            return View();

        }

       
        public ActionResult Contact()
        {
            return View();

        }
        public ActionResult ShopListing()
        {
            return View();

        }


        public ActionResult Blog(int page = 1, int pageSize = 6)
        {
            var articles = db.Articles.OrderByDescending(a => a.ArticleNumber).ToList();
            var totalItems = articles.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginatedArticles = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Приведение данных к ArticleDataModel
            var articleDataModels = paginatedArticles.Select(a => new ArticleDataModel
            {
                ArticleId = a.ArticleId,
                ArticleNumber = a.ArticleNumber,
                ArticleName = a.ArticleName,
                Category = a.Category,
                AuthorName = a.AuthorName,
                TextOfArticle = a.TextOfArticle,
                ImagePath = a.ImagePath
            }).ToList();

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(articleDataModels);
        }

        public ActionResult BlogDetail(int? articleId)
        {
            if (!articleId.HasValue)
            {
                return HttpNotFound("Article id is missing.");
            }

            var article = db.Articles.FirstOrDefault(a => a.ArticleId == articleId.Value);
            if (article == null)
            {
                return HttpNotFound();
            }

            var articleDataModel = new ArticleDataModel
            {
                ArticleId = article.ArticleId,
                ArticleNumber = article.ArticleNumber,
                ArticleName = article.ArticleName,
                Category = article.Category,
                AuthorName = article.AuthorName,
                TextOfArticle = article.TextOfArticle,
                ImagePath = article.ImagePath
            };

            return View(articleDataModel);
        }

        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Wishlist()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ProductDetail()
        {
            return View();
        }

       
    }
}
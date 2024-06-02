using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core;
using WebApplication.BL.DBModel;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeUserController : Controller
    {
        private readonly NewArticleContext db = new NewArticleContext();
        private readonly ProductContext productContext = new ProductContext();
        private List<ArticleDTO> GetSomeArticles(int count)
        {
            return db.Articles
                 .OrderBy(a => a.ArticleId)
                .Take(count)
                .Select(a => new ArticleDTO
                {
                    ArticleId = a.ArticleId,
                    ArticleNumber = a.ArticleNumber,
                    ArticleName = a.ArticleName,
                    Category = a.Category,
                    AuthorName = a.AuthorName,
                    TextOfArticle = a.TextOfArticle,
                    ImagePath = a.ImagePath
                    // Другие свойства по необходимости
                })
                .ToList();
        }
        public ActionResult HomeUsers(UserDataModel userDataModel)
        {
            var articles = GetSomeArticles(3);
            ViewBag.Articles = articles;
            return View(userDataModel);

        }
        public ActionResult About()
        {
            return View();

        }


        public ActionResult Contact()
        {
            return View();

        }
        public ActionResult ShopListing(ProductModel productModel)
        {
            return View(productModel);

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
        public ActionResult Wishlist(UserDataModel userDataModel)
        {
            return View(userDataModel);
        }
        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ProductDetail(int? productId)
        {
            if (!productId.HasValue)
            {
                return HttpNotFound("Product id is missing.");
            }

            var product = productContext.Products.FirstOrDefault(a => a.ProductId == productId.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productModel = new ProductModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                SellCategory = product.SellCategory,
                CategoryByAge = product.CategoryByAge,
                Category = product.Category,
                ProductDetail = product.ProductDetail,
                ImagePath = product.ImagePath
            };

            return View(productModel);
        }





    }
}
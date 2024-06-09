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
using WebApplication.BL.Core;
using System.Drawing.Printing;

namespace OnlineStoreLego.Web.Controllers
{
    public class HomeController : Controller
    {

        private NewArticleContext db = new NewArticleContext();
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
        public ActionResult Index(ProductModel productModel)
        {
            var articles = GetSomeArticles(3);
            ViewBag.Articles = articles;
            return View(productModel);

        }
        public ActionResult About(UserDataModel userDataModel)
        {
            return View(userDataModel);

        }

    
        public ActionResult ShopListing(ProductModel productModel)
        {
            return View(productModel);

        }


        [HttpPost]
        public ActionResult ShopListingSearch(string search)
        {
            var product = productContext.Products // Используем контекст базы данных для получения продукта
                                        .Where(p => p.IsActive) // Фильтрация по активным продуктам
                                        .Where(p => p.ProductName.Contains(search) || p.Category.Contains(search))
                                        .Select(p => new ProductModel
                                        {
                                            ProductName = p.ProductName,
                                            Category = p.Category,
                                            Price = p.Price,
                                            ImagePath = p.ImagePath
                                            // Добавьте другие свойства, если необходимо
                                        })
                                        .FirstOrDefault(); // Предполагаем, что вернется только один продукт

            if (product == null)
            {
                return HttpNotFound(); // Если продукт не найден, возвращаем соответствующий результат
            }

            return View("ShopListing", product);
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

        //public ActionResult Cart(UserDataModel userDataModel)
        //{
        //    return View(userDataModel);
        //}
        //public ActionResult Wishlist(UserDataModel userDataModel)
        //{
        //    return View(userDataModel);
        //}
        //public ActionResult Checkout(UserDataModel userDataModel)
        //{
        //    return View(userDataModel);
        //}

        private readonly ReviewApi _reviewApi = new ReviewApi();
        private readonly ProductApi _productApi = new ProductApi();
        private readonly UserApi _userApi = new UserApi();
        private const int PageSize = 5; // Количество отзывов на одной странице

        public ActionResult ProductDetail(int productId, int page = 1)
        {
            var product = _productApi.GetProductById(productId);
            var reviews = _reviewApi.GetReviewsByProductId(productId);

            var totalReviews = reviews.Count;
            var totalPages = (int)Math.Ceiling((double)totalReviews / PageSize);
            var reviewsToShow = reviews.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var model = new ProductModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                Category = product.Category,
                ProductDetail = product.ProductDetail,
                ImagePath = product.ImagePath,
                Reviews = reviewsToShow
            };

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(model);
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core;
using WebApplication.BL.Core.APIs;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.User;
using WebApplication.Models;
using WebApplication.ViewModels;
using WebApplication.Extensions;
using WebApplication.BL;
using System.Security.Claims;

namespace WebApplication.Controllers
{
    public class HomeUserController : Controller
    {
        private readonly NewArticleContext db = new NewArticleContext();
        private readonly ProductContext productContext = new ProductContext();
        private readonly ReviewApi _reviewApi = new ReviewApi();
        private readonly ProductApi _productApi = new ProductApi();
        private readonly UserApi _userApi = new UserApi();
        private const int PageSize = 5; // Количество отзывов на одной странице

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
        public ActionResult ShopListing()
        {
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            return View(model);
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


        [HttpPost]
        public ActionResult AddReview(ReviewDTO reviewDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _reviewApi.AddReview(reviewDto); // Обновляем метод API для работы с новыми полями
                    Console.WriteLine("Review added successfully");
                }
                catch (Exception ex)
                {
                    // Логирование ошибки
                    Console.WriteLine("Error: " + ex.Message);
                    // Перенаправляем на страницу с подробностями продукта с сообщением об ошибке
                    TempData["ErrorMessage"] = "An error occurred while adding the review. Please try again.";
                    return RedirectToAction("ProductDetail", new { productId = reviewDto.ProductId });
                }

                return RedirectToAction("ProductDetail", new { productId = reviewDto.ProductId });
            }
            // Перенаправляем на страницу с подробностями продукта с сообщением об ошибке
            TempData["ErrorMessage"] = "Invalid review data.";
            return RedirectToAction("ProductDetail", new { productId = reviewDto.ProductId });
        }
        //private int? GetCurrentUserId()
        //{
        //    // Используем идентификатор пользователя из аутентификации
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        // Предполагается, что идентификатор пользователя хранится в User.Identity.Name
        //        // или в другом клайме. Необходимо настроить получение идентификатора пользователя.
        //        // Например, если идентификатор хранится в клайме NameIdentifier:
        //        var claimsIdentity = User.Identity as ClaimsIdentity;
        //        var userIdClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
        //        if (userIdClaim != null)
        //        {
        //            return int.Parse(userIdClaim.Value);
        //        }
        //    }
        //    return null; // Возвращаем null, если пользователь не авторизован
        //}

        //[HttpPost]
        //public ActionResult AddReview(ReviewDTO reviewDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Получаем идентификатор текущего пользователя из аутентификации
        //        int userId = User.Identity.GetUserId();
        //        Console.WriteLine($"Current authenticated UserId: {userId}");

        //        UserDataModel currentUserDataModel = new UserDataModel();
        //        UserDTO currentUser = currentUserDataModel.GetCurrentUser(userId);

        //        if (currentUser == null)
        //        {
        //            Console.WriteLine("User not found in database");
        //            // Перенаправляем на страницу входа или на страницу с подробностями продукта
        //            return RedirectToAction("Login", "Account");
        //        }

        //        reviewDto.UserId = currentUser.UserId;

        //        try
        //        {
        //            _reviewApi.AddReview(reviewDto);
        //            Console.WriteLine("Review added successfully");
        //        }
        //        catch (Exception ex)
        //        {
        //            // Логирование ошибки
        //            Console.WriteLine("Error: " + ex.Message);
        //            // Перенаправляем на страницу с подробностями продукта с сообщением об ошибке
        //            TempData["ErrorMessage"] = "An error occurred while adding the review. Please try again.";
        //            return RedirectToAction("ProductDetail", new { productId = reviewDto.ProductId });
        //        }

        //        return RedirectToAction("ProductDetail", new { productId = reviewDto.ProductId });
        //    }
        //    // Перенаправляем на страницу с подробностями продукта с сообщением об ошибке
        //    TempData["ErrorMessage"] = "Invalid review data.";
        //    return RedirectToAction("ProductDetail", new { productId = reviewDto.ProductId });
        //}
        //private int GetCurrentUserId()
        //    {
        //        // Проверяем, авторизован ли пользователь
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            // Предполагаем, что вы используете аутентификацию, где User.Identity.Name - это имя пользователя
        //            // Вам нужно получить UserId из базы данных на основе имени пользователя

        //            // Пример с использованием User.Identity.Name
        //            string username = User.Identity.Name;

        //            using (var db = new ReviewContext())
        //            {
        //                var user = db.Users.FirstOrDefault(u => u.Username == username);
        //                if (user != null)
        //                {
        //                    return user.UserId;
        //                }
        //                else
        //                {
        //                    // Логируем, если пользователь не найден
        //                    Console.WriteLine($"User not found in database: {username}");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // Логируем, если пользователь не аутентифицирован
        //            Console.WriteLine("User is not authenticated");
        //        }

        //        // Если пользователь не авторизован или не найден в базе данных
        //        return 0;
        //    }
        public ActionResult AddToCart(int productId)
        {
            CartApi cartApi = new CartApi();
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            cartApi.AddToCartInDb(productId, model.UserId);
            return RedirectToAction("ProductDetail", "HomeUser", productId);
        }

        public ActionResult Cart()
        {
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            return View(model);
        }
        public ActionResult Wishlist()
        {
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            return View(model);
        }
        public ActionResult Checkout()
        {
            OrderModel model = new OrderModel()
            {
                //UserId = ((UserDataModel)System.Web.HttpContext.Current.Session["userModel"]).UserId
            };
            return View(model);
        }

        public ActionResult UserAccount()
        {
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            return View(model);
        }

        public ActionResult EditInfo()
        {
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            return View(model);
        }

        public ActionResult ViewOrdersU(UserDataModel userDataModel)
        {
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            return View(model);
        }

        public ActionResult LogOutU()
        {
            UserDataModel model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            return View();
        }


    }
}
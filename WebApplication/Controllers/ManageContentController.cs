using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult AddArticleAction(ArticleDataModel articleDataModel, HttpPostedFileBase ArticleImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ArticleImage != null && ArticleImage.ContentLength > 0)
                    {
                        // Проверка типа файла
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extension = Path.GetExtension(ArticleImage.FileName).ToLower();
                        if (!allowedExtensions.Contains(extension))
                        {
                            ModelState.AddModelError("ArticleImage", "Недопустимый формат файла. Разрешены только .jpg, .jpeg, .png и .gif.");
                            return View(articleDataModel);
                        }

                        // Генерация уникального имени файла
                        var fileName = Path.GetFileNameWithoutExtension(ArticleImage.FileName);
                        fileName = fileName + "_" + Guid.NewGuid() + extension;
                        var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

                        // Сохранение файла
                        ArticleImage.SaveAs(path);

                        // Сохранение пути к изображению в модели
                        articleDataModel.ImagePath = "/Uploads/" + fileName;
                    }

                    // Перемещение данных из модели в DTO
                    ArticleDTO articleDTO = articleDataModel.moveDataFromModelToDTO();
                    ArticleApi articleApi = new ArticleApi();

                    // Обработка запроса к API для сохранения данных в БД
                    articleApi.addArticleToDb(articleDTO);

                    // Перенаправление к методу "ManageContent"
                    return RedirectToAction("ManageContent", articleDataModel);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Произошла ошибка при загрузке изображения: " + ex.Message);
                    return View(articleDataModel);
                }
            }

            return View(articleDataModel);

        }
      

        [HttpPost]
        public ActionResult EditArticle(ArticleDataModel articleDataModel)
        {
            ArticleApi articleApi = new ArticleApi();

            if (articleApi.checkIfArticleNumberExists (articleDataModel.ArticleNumber))
            {
                int articleId = articleApi.getArticleIdByNumber (articleDataModel.ArticleNumber);
                ArticleDTO articleDTO = articleApi.getArticleDTObyId(articleId);
               

                return View(articleDataModel.moveDataFromDTOToModel(articleDTO));
            }
            else
            {
                return RedirectToAction("AddArticle", "ManageContent", articleDataModel);
            }

        }



        //[HttpPost]
        //public ActionResult EditArticleAction(ArticleDataModel articleDataModel, HttpPostedFileBase ArticleImage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var articleApi = new ArticleApi();

        //            if (ArticleImage != null && ArticleImage.ContentLength > 0)
        //            {
        //                // Проверка типа файла
        //                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        //                var extension = Path.GetExtension(ArticleImage.FileName).ToLower();
        //                if (!allowedExtensions.Contains(extension))
        //                {
        //                    ModelState.AddModelError("ArticleImage", "Недопустимый формат файла. Разрешены только .jpg, .jpeg, .png и .gif.");
        //                    return View("EditArticle", articleDataModel);
        //                }

        //                // Генерация уникального имени файла
        //                var fileName = Path.GetFileNameWithoutExtension(ArticleImage.FileName);
        //                fileName = fileName + "_" + Guid.NewGuid() + extension;
        //                var uploadPath = Server.MapPath("~/Uploads/");

        //                // Создание директории, если она не существует
        //                if (!Directory.Exists(uploadPath))
        //                {
        //                    Directory.CreateDirectory(uploadPath);
        //                }

        //                var path = Path.Combine(uploadPath, fileName);

        //                // Сохранение файла
        //                ArticleImage.SaveAs(path);

        //                // Сохранение пути к изображению в модели
        //                articleDataModel.ImagePath = "/Uploads/" + fileName;
        //            }
        //            else
        //            {
        //                // Если новое изображение не загружено, сохраняем путь к текущему изображению
        //                ArticleDTO currentArticleDTO = articleApi.getArticleDTObyId(articleDataModel.ArticleNumber);
        //                if (currentArticleDTO != null)
        //                {
        //                    articleDataModel.ImagePath = currentArticleDTO.ImagePath;
        //                }
        //            }

        //            // Перемещение данных из модели в DTO
        //            ArticleDTO articleDTO = articleDataModel.moveDataFromModelToDTO();

        //            // Логирование перед вызовом API
        //            Console.WriteLine($"Calling editItemInDb with: {articleDTO.ArticleNumber}, {articleDTO.ArticleName}, {articleDTO.Category}, {articleDTO.AuthorName}, {articleDTO.TextOfArticle}, {articleDTO.ImagePath}");

        //            // Обработка запроса к API для сохранения данных в БД
        //            var updateResult = articleApi.editItemInDb(articleDTO);

        //            // Проверка результата обновления
        //            if (updateResult)
        //            {
        //                Console.WriteLine("Article updated successfully in the database.");
        //                return RedirectToAction("ManageContent");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Не удалось обновить статью. Проверьте данные и попробуйте еще раз.");
        //                return View("EditArticle", articleDataModel);
        //            }
        //        }
        //        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        //        {
        //            foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            {
        //                foreach (var validationError in validationErrors.ValidationErrors)
        //                {
        //                    ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
        //                }
        //            }
        //            return View("EditArticle", articleDataModel);
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Произошла ошибка при загрузке изображения: " + ex.Message);
        //            return View("EditArticle", articleDataModel);
        //        }
        //    }

        //    return View("EditArticle", articleDataModel);
        //}

        [HttpPost]
        public ActionResult EditArticleAction(ArticleDataModel articleDataModel, HttpPostedFileBase ArticleImage, string ImageOption)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var articleApi = new ArticleApi();

                    if (ImageOption == "new" && ArticleImage != null && ArticleImage.ContentLength > 0)
                    {
                        // Проверка типа файла
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extension = Path.GetExtension(ArticleImage.FileName).ToLower();
                        if (!allowedExtensions.Contains(extension))
                        {
                            ModelState.AddModelError("ArticleImage", "Недопустимый формат файла. Разрешены только .jpg, .jpeg, .png и .gif.");
                            return View("EditArticle", articleDataModel);
                        }

                        // Генерация уникального имени файла
                        var fileName = Path.GetFileNameWithoutExtension(ArticleImage.FileName);
                        fileName = fileName + "_" + Guid.NewGuid() + extension;
                        var uploadPath = Server.MapPath("~/Uploads/");

                        // Создание директории, если она не существует
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        var path = Path.Combine(uploadPath, fileName);

                        // Сохранение файла
                        ArticleImage.SaveAs(path);

                        // Сохранение пути к изображению в модели
                        articleDataModel.ImagePath = "/Uploads/" + fileName;
                    }
                    else if (ImageOption == "current")
                    {
                        // Сохранение текущего изображения
                        ArticleDTO currentArticleDTO = articleApi.getArticleDTObyId(articleDataModel.ArticleNumber);
                        if (currentArticleDTO != null)
                        {
                            articleDataModel.ImagePath = currentArticleDTO.ImagePath;
                        }
                    }

                    // Перемещение данных из модели в DTO
                    ArticleDTO articleDTO = articleDataModel.moveDataFromModelToDTO();

                    // Логирование перед вызовом API
                    Console.WriteLine($"Calling editItemInDb with: {articleDTO.ArticleNumber}, {articleDTO.ArticleName}, {articleDTO.Category}, {articleDTO.AuthorName}, {articleDTO.TextOfArticle}, {articleDTO.ImagePath}");

                    // Обработка запроса к API для сохранения данных в БД
                    var updateResult = articleApi.editItemInDb(articleDTO);

                    // Проверка результата обновления
                    if (updateResult)
                    {
                        Console.WriteLine("Article updated successfully in the database.");
                        return RedirectToAction("ManageContent");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не удалось обновить статью. Проверьте данные и попробуйте еще раз.");
                        return View("EditArticle", articleDataModel);
                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                    return View("EditArticle", articleDataModel);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Произошла ошибка при загрузке изображения: " + ex.Message);
                    return View("EditArticle", articleDataModel);
                }
            }

            return View("EditArticle", articleDataModel);
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
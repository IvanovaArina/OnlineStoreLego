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
    public class ManageProductController : Controller
    {
        // GET: ManageProduct
        [HttpGet]
        public ActionResult Index(ProductModel productModel)
        {
            return View(productModel);
        }

        [HttpGet]
        public ActionResult CreateProduct(ProductModel productModel)
        {
            return View(productModel);
        }



        //[HttpPost]
        //public ActionResult CreateProductAction(ProductModel productModel, HttpPostedFileBase ProductImage) 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (ProductImage != null && ProductImage.ContentLength > 0)
        //            {
        //                // Проверка типа файла
        //                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        //                var extension = Path.GetExtension(ProductImage.FileName).ToLower();
        //                if (!allowedExtensions.Contains(extension))
        //                {
        //                    ModelState.AddModelError("ProductImage", "Недопустимый формат файла. Разрешены только .jpg, .jpeg, .png и .gif.");
        //                    return View(productModel);
        //                }

        //                // Генерация уникального имени файла
        //                var fileName = Path.GetFileNameWithoutExtension(ProductImage.FileName);
        //                fileName = fileName + "_" + Guid.NewGuid() + extension;
        //                var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

        //                // Создание директории, если она не существует
        //                if (!Directory.Exists(path))
        //                {
        //                    Directory.CreateDirectory(path);
        //                }

        //                // Сохранение файла
        //                ProductImage.SaveAs(path);

        //                // Сохранение пути к изображению в модели
        //                productModel.ImagePath = "/Uploads/" + fileName;
        //            }

        //            // Перемещение данных из модели в DTO
        //            ProductDTO productDTO = productModel.MoveDataFromModelToDTO();
        //            ProductApi productApi = new ProductApi();

        //            // Обработка запроса к API для сохранения данных в БД
        //            productApi.addProductToDb(productDTO);

        //            // Перенаправление к методу "ManageProducts"
        //            return RedirectToAction("Index", productModel);
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Произошла ошибка при загрузке изображения: " + ex.Message);
        //            return View(productModel);
        //        }
        //    }

        //    return View(productModel);
        //}

        public ActionResult CreateProductAction(ProductModel productModel, HttpPostedFileBase ProductImage)
        {
            if (!ModelState.IsValid)
            {
                // Log all validation errors
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }

                // Optionally, add the errors to the model and pass to the view
                ViewBag.Errors = errors;

                return View("CreateProduct", productModel);
            }

            try
            {
                if (ProductImage != null && ProductImage.ContentLength > 0)
                {
                    // Проверка типа файла
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(ProductImage.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("ProductImage", "Недопустимый формат файла. Разрешены только .jpg, .jpeg, .png и .gif.");
                        return View("CreateProduct", productModel);
                    }

                    // Генерация уникального имени файла
                    var fileName = Path.GetFileNameWithoutExtension(ProductImage.FileName);
                    fileName = fileName + "_" + Guid.NewGuid() + extension;
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

                    // Создание директории, если она не существует
                    if (!Directory.Exists(Server.MapPath("~/Uploads/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Uploads/"));
                    }

                    // Сохранение файла
                    ProductImage.SaveAs(path);

                    // Сохранение пути к изображению в модели
                    productModel.ImagePath = "/Uploads/" + fileName;
                }

                // Перемещение данных из модели в DTO
                ProductDTO productDTO = productModel.MoveDataFromModelToDTO();
                ProductApi productApi = new ProductApi();

                // Обработка запроса к API для сохранения данных в БД
                productApi.addProductToDb(productDTO);

                // Перенаправление к методу "Index"
                return RedirectToAction("Index", "ManageProduct");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Произошла ошибка при загрузке изображения: " + ex.Message);
                return View("CreateProduct", productModel);
            }
        }



        [HttpPost]
        public ActionResult EditProduct(ProductModel productModel)
        {
            ProductApi productApi = new ProductApi();

            if (productApi.checkIfProductNumberExists(productModel.ProductNumber))
            {
                int productId = productApi.getProductIdByNumber(productModel.ProductNumber);
                ProductDTO productDTO = productApi.getProductDTObyId(productId);

                return View(productModel.MoveDataFromDTOToModel(productDTO));
            }
            else
            {
                return RedirectToAction("CreateProduct", "Index", productModel);
            }

        }

        //[HttpPost]
        //public ActionResult EditProductAction(ProductModel productModel)
        //{
        //    ProductDTO productDTO = productModel.MoveDataFromModelToDTO();
        //    ProductApi productApi = new ProductApi();

        //    productApi.editProductInDb(productDTO);

        //    return View("Index", productModel);

        //}

        [HttpPost]
        public ActionResult EditProductAction(ProductModel productModel, HttpPostedFileBase ProductImage, string ImageOption)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productApi = new ProductApi();

                    if (ImageOption == "new" && ProductImage != null && ProductImage.ContentLength > 0)
                    {
                        // Проверка типа файла
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extension = Path.GetExtension(ProductImage.FileName).ToLower();
                        if (!allowedExtensions.Contains(extension))
                        {
                            ModelState.AddModelError("ProductImage", "Недопустимый формат файла. Разрешены только .jpg, .jpeg, .png и .gif.");
                            return View("EditProduct", productModel);
                        }

                        // Генерация уникального имени файла
                        var fileName = Path.GetFileNameWithoutExtension(ProductImage.FileName);
                        fileName = fileName + "_" + Guid.NewGuid() + extension;
                        var uploadPath = Server.MapPath("~/Uploads/");

                        // Создание директории, если она не существует
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        var path = Path.Combine(uploadPath, fileName);

                        // Сохранение файла
                        ProductImage.SaveAs(path);

                        // Сохранение пути к изображению в модели
                        productModel.ImagePath = "/Uploads/" + fileName;
                    }
                    else if (ImageOption == "current")
                    {
                        // Сохранение текущего изображения
                        ProductDTO currentProductDTO = productApi.getProductDTObyId(productModel.ProductNumber);
                        if (currentProductDTO != null)
                        {
                            productModel.ImagePath = currentProductDTO.ImagePath;
                        }
                    }

                    // Перемещение данных из модели в DTO
                    ProductDTO productDTO = productModel.MoveDataFromModelToDTO();

                    // Логирование перед вызовом API
                    Console.WriteLine($"Calling editProductInDb with: {productDTO.ProductNumber}, {productDTO.ProductName}, {productDTO.Category}, {productDTO.Price}, {productDTO.ImagePath}");

                    // Обработка запроса к API для сохранения данных в БД
                    var updateResult = productApi.editItemInDb(productDTO);

                    // Проверка результата обновления
                    if (updateResult)
                    {
                        Console.WriteLine("Product updated successfully in the database.");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не удалось обновить продукт. Проверьте данные и попробуйте еще раз.");
                        return View("EditProduct", productModel);
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
                    return View("EditProduct", productModel);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Произошла ошибка при загрузке изображения: " + ex.Message);
                    return View("EditProduct", productModel);
                }
            }

            return View("EditProduct", productModel);
        }

        [HttpPost]
        public ActionResult DeleteProduct(ProductModel productModel)
        {
            ProductApi productApi = new ProductApi();
            productApi.deleteProduct(productModel.ProductNumber);

            return View("Index", productModel);
        }

        public ActionResult AdminAccount()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }

        public ActionResult ManageUsers()
        {
            return RedirectToAction("ManageUsers", "Admin");
        }

        //public ActionResult ManageProducts(ProductModel productModel)
        //{
        //    return RedirectToAction("ManageProducts", "Admin", productModel);
        //}
        public ActionResult ManageReview(ReviewModel reviewModel)
        {
            return RedirectToAction("ManageReview", "Admin", reviewModel);
        }

        public ActionResult ViewOrders()
        {
            return RedirectToAction("ViewOrders", "Admin");
        }

        public ActionResult ManageContent()
        {
            return RedirectToAction("ManageContent", "ManageContent");
        }
    }
}
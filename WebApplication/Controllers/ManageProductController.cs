using System;
using System.Collections.Generic;
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

        [HttpPost]
        public ActionResult CreateProductAction(ProductModel productModel)
        {
            ProductDTO productDTO = productModel.MoveDataFromModelToDTO();
            ProductApi productApi = new ProductApi();

            //??
            productApi.addProductToDb(productDTO);
            return RedirectToAction("Index", productModel);
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

        [HttpPost]
        public ActionResult EditProductAction(ProductModel productModel)
        {
            ProductDTO productDTO = productModel.MoveDataFromModelToDTO();
            ProductApi productApi = new ProductApi();

            productApi.editProductInDb(productDTO);

            return View("Index", productModel);

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
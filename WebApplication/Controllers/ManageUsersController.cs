using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ManageUsersController : Controller
    {
        [HttpGet]
        public ActionResult ManageUsers (UserDataModel userDataModel)
        {
            return View(userDataModel);
        }

        public ActionResult AdminAccount()
        {
            return RedirectToAction("AdminAccount", "Admin");
        }

        public ActionResult ManageContent()
        {
            return RedirectToAction("ManageContent", "Admin");
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

        [HttpGet]
        public ActionResult AddUser(UserDataModel userDataModel)
        {
            return View(userDataModel);
        }

        [HttpPost]
        public ActionResult EditUser(UserDataModel userDataModel)
        {
            return View(userDataModel);
        }


        [HttpPost]
        public ActionResult DeleteUser(UserDataModel userDataModel)
        {
            return View(userDataModel);
        }


        [HttpPost]
        public ActionResult AddUserAction(UserDataModel userDataModel)
        {
            //sign up



            //var userDTO = Mapper.Map<UserDTO>(userDataModel);
            //UserApi userApi = new UserApi();

            ////обработать Base Answer
            //userApi.addUserToDb(userDTO);

            return RedirectToAction("ManageUsers", userDataModel);

        }

        [HttpPost]
        public ActionResult EditUserAction(UserDataModel userDataModel)
        {

            //ArticleDTO articleDTO = articleDataModel.moveDataFromModelToDTO();
            //ArticleApi articleApi = new ArticleApi();

            ////обработать Base Answer
            //articleApi.editArticleInDb(articleDTO);


            return View("ManageUsers", userDataModel);
        }


















    }
}
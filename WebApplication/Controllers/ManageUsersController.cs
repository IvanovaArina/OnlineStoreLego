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

        public ActionResult ManageProduct(ProductModel productModel)
        {
            return RedirectToAction("ManageProduct", "Admin", productModel);
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
            UserApi userApi = new UserApi();

            if (userApi.checkIfUserIdExists(userDataModel.UserId))
            {
                UserDTO userDTO = userApi.getUserDTObyId(userDataModel.UserId);
                return View(userDataModel.moveDataFromDTOToModel(userDTO));
            }
            else
            {
                return RedirectToAction("AddUser", "ManageUsers", userDataModel);
            }
        }


        [HttpPost]
        public ActionResult EditUserAction(UserDataModel userDataModel)
        {
            UserDTO userDTO = userDataModel.moveDataFromModelToDTO();
            UserApi userApi = new UserApi();

            userApi.editUserInDb (userDTO);

            return View("ManageUsers", userDataModel);
        }


        [HttpPost]
        public ActionResult DeleteUser(UserDataModel userDataModel)
        {
            UserApi userApi = new UserApi();
            userApi.deleteUser(userDataModel.UserId);

            return View("ManageUsers", userDataModel);
        }


        [HttpPost]
        public ActionResult AddUserAction(UserDataModel userDataModel)
        {

            UserDTO userDTO = userDataModel.moveDataFromModelToDTO();

            UserApi userApi = new UserApi();
            userApi.addUserToDb(userDTO);

            return RedirectToAction("ManageUsers", userDataModel);

        }

       


















    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.DBModel;
using WebApplication.BL.Interfaces;
using WebApplication.BL;
using WebApplication.Domain.Entities.Enums;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Domain.Entities.User;
using WebApplication.Models;
using AutoMapper;
using System.Web.Security;
using WebApplication.BL.Core;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {

        private UserContext db = new UserContext();//gbf
        private ProductContext db1 = new ProductContext();//gbf
        private readonly ISession _session;


        public LoginController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();

        }
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserDataModel userModel)
        {
            var adress = base.Request.UserHostAddress;
            var ulData = new UserDTO
            {
                Email = userModel.Email,
                Password = userModel.Password
            };

            BaseResponces resp = _session.ValidateUserCredentialAction(ulData);

            if (resp.Status)
            {
                HttpCookie cookie = _session.GenCookie(ulData.Email);
                ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                UserApi userApi = new UserApi();
                UDbTable userDb = userApi.findUserByEmail(ulData.Email);

                var r = userApi.getUserDTObyId(userDb.UserId);
                userModel = userModel.moveDataFromDTOToModel(r);

                System.Web.HttpContext.Current.Session["userModel"] = userModel;

                // Роль пользователя уже определена в объекте resp, полученном от _session.ValidateUserCredentialAction
                switch (resp.Role)
                {
                    case URole.Admin:
                        // Если пользователь - админ, перенаправляем на страницу админа
                        return RedirectToAction("AdminAccount", "Admin", userModel);
                    case URole.User:
                        // Если пользователь не админ, перенаправляем на обычную страницу пользователя
                        return RedirectToAction("ShopListing", "HomeUser");
                    default:
                        // Если роль пользователя неопределенная или не ожидаемая, обработайте это соответствующим образом
                        ViewBag.ErrorMessage = "Your role is not recognized by the system.";
                        return View();
                }
            }
            else
            {
                // Handle invalid login attempt
                if (resp.ErrorCode == "EmailNotExist")
                {
                    ModelState.AddModelError("Email", "This email address does not exist.");
                }
                else if (resp.ErrorCode == "IncorrectPassword")
                {
                    ModelState.AddModelError("Password", "The password is incorrect.");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid login attempt";
                }
                return View(userModel);
                //never happen
            }


        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult UAccountHome()
        {
            return View();

        }

        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");

        }

        public ActionResult About()
        {
            return RedirectToAction("About", "Home");

        }


      
        public ActionResult ShopListing()
        {
            return RedirectToAction("ShopListing", "Home");

        }


        public ActionResult Blog()
        {
            return RedirectToAction("Blog", "Home");
        }

        public ActionResult Contact()
        {
            return RedirectToAction("Contact", "Home");
        }


        public ActionResult Cart()
        {
            return RedirectToAction("Cart", "Home");
        }
        public ActionResult Wishlist()
        {
            return RedirectToAction("Wishlist", "Home");
        }
       

       


        public ActionResult AdminAccountHome()
        {
            return View();

        }


        [HttpPost]
        public ActionResult SignUpUser(UserDataModel userModel)
        {
            BaseResponces resp = SignUp(userModel);
            if (!resp.Status)
            {
                ModelState.AddModelError("", resp.StatusMessage);
                return View("SignUp", userModel);
            }


            return RedirectToAction("LogIn", "Login");
        }

        [HttpPost]
        public ActionResult SignUpAdmin(UserDataModel userModel)
        {
            BaseResponces resp = SignUp(userModel);
            if (!resp.Status)
            {
                ModelState.AddModelError("", resp.StatusMessage);
                return View("AddUser", "ManageUsers", userModel);
            }


            return RedirectToAction("ManageUsers", "ManageUsers", userModel);
        }





        private BaseResponces SignUp(UserDataModel userModel)
        {
            var address = base.Request.UserHostAddress;

            URole role = new URole();

            if (userModel.KeyCredential == "cisco1234")
            {
                role = URole.Admin;
            }
            else
            {
                role = URole.User;
            }

            var udata = new UserDTO()
            {

                ConfirmPassword = userModel.ConfirmPassword,
                Password = userModel.Password,
                Email = userModel.Email,
                Role = role,
                //UserIp = adress,
                Username = userModel.Username,

                //Wishlist = new WishlistEntity()
            };

            //BaseResponces resp = _session.RegisterUserActionFlow(udata);
            return _session.RegisterUserActionFlow(udata);

        }

    }
}
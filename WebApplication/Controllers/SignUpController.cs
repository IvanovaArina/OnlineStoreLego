//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using WebApplication.BL.Core;
//using WebApplication.BL.Interfaces;
//using WebApplication.Domain.Entities.Enums;
//using WebApplication.Domain.Entities.Responces;
//using WebApplication.Models;

//namespace WebApplication.Controllers
//{
//    public class SignUpController : Controller
//    {
//        [HttpGet]
//        public ActionResult SignUp(ISession _session)
//        {

//            return View();
//        }

//        [HttpPost]
//        public ActionResult SignUpUser(UserDataModel userModel, ISession _session)
//        {
//            BaseResponces resp = SignUp(userModel, _session);
//            if (!resp.Status)
//            {
//                ModelState.AddModelError("", resp.StatusMessage);
//                return View("SignUp", userModel);
//            }


//            return RedirectToAction("LogIn", "Login");
//        }

//        [HttpPost]
//        public ActionResult SignUpAdmin(UserDataModel userModel, ISession _session)
//        {
//            BaseResponces resp = SignUp(userModel, _session);
//            if (!resp.Status)
//            {
//                ModelState.AddModelError("", resp.StatusMessage);
//                return View("AddUser", "ManageUsers", userModel);
//            }


//            return RedirectToAction("ManageUsers", "ManageUsers", userModel);
//        }





//        private BaseResponces SignUp(UserDataModel userModel, ISession _session)
//        {
//            var address = base.Request.UserHostAddress;

//            URole role = new URole();

//            if (userModel.KeyCredential == "cisco1234")
//            {
//                role = URole.Admin;
//            }
//            else
//            {
//                role = URole.User;
//            }

//            var udata = new UserDTO()
//            {

//                ConfirmPassword = userModel.ConfirmPassword,

//                Password = userModel.Password,
//                Email = userModel.Email,
//                Role = role,
//                UserIp = adress,
//                Username = userModel.Username,

//                Wishlist = new WishlistEntity()
//            };

//            BaseResponces resp = _session.RegisterUserActionFlow(udata);
//            return _session.RegisterUserActionFlow(udata);

//        }

//    }
//}
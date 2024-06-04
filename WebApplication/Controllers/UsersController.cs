using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserApi _userApi;

        public UsersController()
        {
            _userApi = new UserApi();
        }

        // GET: Users
        public ActionResult UserAccount(UserDataModel userDataModel)
        {
            return View(userDataModel);
        } 
        
        public ActionResult UserAccountWithString(string userDataModel)
        {
            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDataModel>(userDataModel);

            return View("UserAccount", model);
        }

        public ActionResult EditInfo(UserDataModel userDataModel)
        {
            return View();
        }

        public ActionResult ViewOrdersU(UserDataModel userDataModel)
        {
            return View();
        }

        public ActionResult LogOutU()
        {
            return View();
        }
    }
}
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
            //var userDTO = _userApi.getUserDTObyId(userDataModel.UserId);

            //var model = userDataModel.moveDataFromDTOToModel(userDTO);

            return View(userDataModel);
        }

        public ActionResult EditInfo()
        {
            return View();
        }

        public ActionResult ViewOrdersU()
        {
            return View();
        }

        public ActionResult LogOutU()
        {
            return View();
        }
    }
}
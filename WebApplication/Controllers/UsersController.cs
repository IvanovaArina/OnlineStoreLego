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
        public ActionResult UserAccount()
        {
            // Получите данные текущего пользователя
            var currentUserId = 1; // Пример. Здесь нужно указать идентификатор текущего пользователя
            var userDTO = _userApi.getUserDTObyId(currentUserId);

            // Создайте экземпляр модели и заполните её данными
            var model = new UserDataModel
            {
                Username = userDTO.Username
                // Заполните другие свойства, если необходимо
            };

            // Передайте модель в представление
            return View(model);
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
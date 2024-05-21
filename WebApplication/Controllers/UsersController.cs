using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult UserAccount()
        {
            return View();
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
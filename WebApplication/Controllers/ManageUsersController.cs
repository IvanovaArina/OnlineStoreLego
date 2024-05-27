using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ManageUsersController : Controller
    {
        [HttpGet]
        public ActionResult ManageUsers ()
        {
            return View();
        }
    }
}
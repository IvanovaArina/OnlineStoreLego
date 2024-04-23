using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL;
using WebApplication.BL.DBModel;
using WebApplication.BL.Interfaces;
using WebApplication.Domain.Entities.User;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Models;
using AutoMapper;
using System.Web.Security;
using System.Web.UI.WebControls;

using System.Threading.Tasks;
using WebApplication.Domain.Entities.Enums;

namespace OnlineStoreLego.Web.Controllers
{
    public class HomeController : Controller
    {

        //private UserContext db = new UserContext();//gbf
        //private readonly ISession _session;


        //public HomeController()
        //{
        //    var bl = new BusinessLogic();
        //    _session = bl.GetSessionBL();

        //}

        // GET: Home
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult About()
        {
            return View();

        }

        //public ActionResult UAccountHome()
        //{
        //    return View();

        //}
        public ActionResult Contact()
        {
            return View();

        }
        public ActionResult ShopListing()
        {
            return View();

        }
    //    public ActionResult LogIn()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult LogIn(UserData userModel)
    //    {
    //        var adress = base.Request.UserHostAddress;
    //        var ulData = new ULoginData
    //        {
    //            Email = userModel.Email,
    //            UserIp = adress,
    //            UserName=userModel.FullName,
    //            Password = userModel.Password,
                
    //        };
            
    //        BaseResponces resp = _session.ValidateUserCredentialAction(ulData);

    //         if (resp.Status)
    //{
    //    HttpCookie cookie = _session.GenCookie(ulData.Email);
    //    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

    //    // Роль пользователя уже определена в объекте resp, полученном от _session.ValidateUserCredentialAction
    //    switch (resp.Role)
    //    {
    //        case URole.Admin:
    //            // Если пользователь - админ, перенаправляем на страницу админа
    //            return RedirectToAction("AdminAccount", "Home");
    //        case URole.User:
    //            // Если пользователь не админ, перенаправляем на обычную страницу пользователя
    //            return RedirectToAction("UAccountHome", "Home");
    //        default:
    //            // Если роль пользователя неопределенная или не ожидаемая, обработайте это соответствующим образом
    //            ViewBag.ErrorMessage = "Your role is not recognized by the system.";
    //            return View();
    //    }
    //}
    //else
    //{
    //    // Обработка ошибки входа
    //    ViewBag.ErrorMessage = "Invalid login attempt";
    //    return View();
    //}


    //    }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult BlogDetail()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Wishlist()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ProductDetail()
        {
            return View();
        }

        //public ActionResult SignIn()
        //{
        //    return View(new UserSignIn());
        //}

        //[HttpPost]
        //public ActionResult SignIn(UserSignIn userModel)
        //{
        //    var adress = base.Request.UserHostAddress;
        //    var udata = new USignInData()
        //    {
        //        Country = userModel.Country,
        //        ConfirmPassword=userModel.ConfirmPassword,
        //        City = userModel.City,
        //        PhoneNumber = userModel.PhoneNumber,
        //        Password = userModel.Password,
        //        Email = userModel.Email,
        //        Level = userModel.Level,
        //        UserIp=adress,
        //        FullName = userModel.FullName
        //    };

        //    var userSI = Mapper.Map<USignInData>(udata);
        //    BaseResponces resp=_session.RegisterUserActionFlow(userSI);

        //    return RedirectToAction("LogIn", "Home");
        //}
    


       

        //public ActionResult UserAccount() //панель пользователя 
        //{
        //    return View();
        //}

        //public ActionResult AdminAccount() //панель админа
        //{
        //    return View();
        //}

        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut(); 
        //    return RedirectToAction("Index", "Home");
        //}

    }
}
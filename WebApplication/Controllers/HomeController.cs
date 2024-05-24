﻿using System;
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

        
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult About()
        {
            return View();

        }

       
        public ActionResult Contact()
        {
            return View();

        }
        public ActionResult ShopListing()
        {
            return View();

        }
    

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

       
    }
}
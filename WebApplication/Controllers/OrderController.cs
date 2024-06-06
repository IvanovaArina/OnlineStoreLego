using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core.APIs;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {
        OrderApi orderApi = new OrderApi();
        public ActionResult AddOrder(OrderModel orderModel)
        {
            orderModel.UserId= ((UserDataModel)System.Web.HttpContext.Current.Session["userModel"]).UserId;
            orderApi.AddOrderInDb();
            orderApi.CleanCart();
            return RedirectToAction("Cart", "HomeUser");
        } 
        
        //public ActionResult ShowAmount()
        //{
        //    orderApi.ShowAmountOfCart();
        //    return RedirectToAction("Checkout", "HomeUser");
        //}



    }
}
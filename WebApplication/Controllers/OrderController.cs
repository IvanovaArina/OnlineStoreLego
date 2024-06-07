using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BL.Core.APIs;
using WebApplication.BL.Core.DTOs;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {
        OrderApi orderApi = new OrderApi();
        public ActionResult AddOrder(OrderModel orderModel)
        {
            var model = (UserDataModel)System.Web.HttpContext.Current.Session["userModel"];
            //orderModel.orderId = model.OrderId;
            //? - saveChanges
            int orderId = orderApi.AddOrderInDb(model.CartId);

            OrderDTO orderDTO = orderModel.moveDataFromModelToDTO();
            orderDTO.userId = model.UserId;
            orderApi.SaveOrderDetails(orderDTO, orderId, model.UserId);
            
            return RedirectToAction("Cart", "HomeUser");
        } 
        
        //public ActionResult ShowAmount()
        //{
        //    orderApi.ShowAmountOfCart();
        //    return RedirectToAction("Checkout", "HomeUser");
        //}



    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.Domain.Entities.User;
using WebApplication.BL.Core;
using WebApplication.BL.Core.DTOs;

namespace WebApplication.Models
{
    public class MyIntOrderModel
    {
        public int MyIntOrderId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }

        // Внешний ключ для связи с OrderTable
        public int? OrderId { get; set; }

        //// Навигационное свойство для связи с OrderTable
        //[ForeignKey("OrderId")]
        public virtual OrderTable Order { get; set; }

        public MyIntOrderModel moveDataFromDTOToModel(MyIntOrderDTO orderDTO)
        {
            MyIntOrderModel myIntOrderModel = new MyIntOrderModel
            {
                MyIntOrderId = orderDTO.MyIntOrderId,
                ProductId = orderDTO.ProductId,
                Count = orderDTO.Count,
                OrderId = orderDTO.OrderId,
                Order = orderDTO.Order
            };

            return myIntOrderModel;
        }

    }
}
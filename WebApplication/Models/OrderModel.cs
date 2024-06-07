using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;
using WebApplication.BL.Core.DTOs;
using WebApplication.Domain.Entities.User;

namespace WebApplication.Models
{
    public class OrderModel
    {
        public int orderId { get; set; }
        public int userId { get; set; }
        public int orderNumber { get; set; }

        public int testOrder { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string ShippingAddress { get; set; }
        public List<MyIntOrder> MyIntsOrder { get; set; } = new List<MyIntOrder>();


        public OrderDTO moveDataFromModelToDTO()
        {
            return new OrderDTO
            {
                orderId = this.orderId,
                userId = this.userId,
                orderNumber = this.orderNumber, 
                testOrder = this.testOrder,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Country = this.Country,
                ShippingAddress = this.ShippingAddress,
                MyIntsOrder = this.MyIntsOrder
            };

    }
    }
}
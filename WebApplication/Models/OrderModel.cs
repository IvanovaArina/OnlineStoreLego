using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;
using WebApplication.BL.Core.APIs;
using WebApplication.BL.Core.DTOs;
using WebApplication.Domain.Entities.Admin;
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

        public OrderModel moveDataFromDTOToModel(OrderDTO orderDTO)
        {
            return new OrderModel
            {
                orderId = orderDTO.orderId,
                userId = orderDTO.userId,
                orderNumber = orderDTO.orderNumber,
                testOrder = orderDTO.testOrder,
                FirstName = orderDTO.FirstName,
                LastName = orderDTO.LastName,
                Email = orderDTO.Email,
                PhoneNumber = orderDTO.PhoneNumber,
                Country = orderDTO.Country,
                ShippingAddress = orderDTO.ShippingAddress,
                MyIntsOrder = orderDTO.MyIntsOrder
            };

        }

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


        public Dictionary<ProductDTO, int> dataForTableOrderProducts(int orderId)
        {
            var orderApi = new OrderApi();
            return orderApi.getProductsFromOrder(orderId);
        }

        //List<int> count = Model.getCountsOfProducts(productTable);
        //public List<int> getCountsOfProducts(List<Pro>)
        //{
        //    var orderApi = new OrderApi();
        //    return orderApi.getProductsFromOrder(orderId);
        //}
    }
}
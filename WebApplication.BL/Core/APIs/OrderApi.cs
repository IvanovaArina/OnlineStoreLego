﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core.APIs
{
    public class OrderApi
    {
        public OrderTable createOrderTable(int id)
        {
            OrderTable Order = null;
            using (var context = new OrderContext())
            {
                Order = new OrderTable
                {
                    testOrder = 88,

                    UserId = id
                };


                context.Orders.Add(Order);
                context.SaveChanges();
            }

            return Order;
        }


        public void AddOrderInDb()
        {

        }
        public void CleanCart()
        {

        }



    }
}
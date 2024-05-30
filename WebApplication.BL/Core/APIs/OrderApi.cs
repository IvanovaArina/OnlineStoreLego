using System;
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

                var prod1 = new ProductTable
            {
                ProductNumber = 33,
                ProductName = "33",
                Price = 200,
                CategoryByAge = "CategoryByAge",
                Category = "Category",
                SellCategory = "SellCategory",
                Quantity = 50,
                IsActive = true
            };

            var prod2 = new ProductTable
            {
                ProductNumber = 66,
                ProductName = "66",
                Price = 66,
                CategoryByAge = "CategoryByAge2",
                Category = "Category2",
                SellCategory = "SellCategory2",
                Quantity = 5002,
                IsActive = false
            };

            Order = new OrderTable
            {
                testOrder = 88,

                Products = new Dictionary<ProductTable, int>
                    {
                        { prod1 , 90 },
                        {prod2 , 89 },
                },

                UserId = id
            };
                

                context.Orders.Add(Order);
                context.SaveChanges();
            }

            return Order;
        }


        //public BaseResponces addUserToOrderTable (string email)
        //{

        //    UDbTable dbUser = null;
        //    using (var db = new UserContext())
        //    {
        //        dbUser = db.Users.FirstOrDefault(x => x.Email == email);
        //    }



        //    return new BaseResponces { Status = false, StatusMessage = "Didn't add" };
        //    return new BaseResponces { Status = true, StatusMessage = "added" };
        
        //}



    }
}

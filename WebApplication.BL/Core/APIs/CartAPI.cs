using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core.APIs
{
    public class CartApi
    {


        public void deleteCart(int cartId)
        {
            using (var context = new CartContext())
            {
                var cartDb = context.Carts.FirstOrDefault(p => p.cartId == cartId);

                if (cartDb != null)
                {
                    context.Carts.Remove(cartDb);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }
            }
        }



        public CartTable createCartTable()
        {
            CartTable Cart = null;
            using (var context = new CartContext())
            {

                //    var prod1 = new ProductTable
                //{
                //    ProductNumber = 33,
                //    ProductName = "ProductName",
                //    Price = 20,
                //    CategoryByAge = "CategoryByAge",
                //    Category = "Category",
                //    SellCategory = "SellCategory",
                //    Quantity = 500,
                //    IsActive = true,
                //    ImagePath = "ImagePath"
                //    };

                //var prod2 = new ProductTable
                //{
                //    ProductNumber = 44,
                //    ProductName = "ProductName2",
                //    Price = 202,
                //    CategoryByAge = "CategoryByAge2",
                //    Category = "Category2",
                //    SellCategory = "SellCategory2",
                //    Quantity = 5002,
                //    IsActive = false,
                //    ImagePath = "ImagePath"
                //};

            Cart = new CartTable
            {
                testCart = 55,

                Products = new Dictionary<int, int> ()
            };

            context.Carts.Add(Cart);
            context.SaveChanges();
            }

            return Cart;
        }
    }
}

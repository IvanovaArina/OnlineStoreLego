using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core
{
    public class WishlistApi
    {

        public void deleteWishlist(int wishlistId)
        {
            using (var context = new WishlistContext())
            {
                var wishlistDb = context.Wishlists.FirstOrDefault(p => p.wishlistId == wishlistId);

                if (wishlistDb != null)
                {
                    context.Wishlists.Remove(wishlistDb);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }
            }
        }


        public WishlistTable createWishlistTable()
        {
            WishlistTable Wishlist = null;
            //using (var context = new WishlistContext())
            //{
                Wishlist = new WishlistTable
                {
                    test = 2,
                    //wishlistEntity = new List<int>()
                    Products = new List<ProductTable>
                    {
                        new ProductTable { ProductNumber = 1,
                        ProductName = "ProductName",
                        Price = 20,
                        CategoryByAge = "CategoryByAge",
                        Category = "Category",
                        SellCategory = "SellCategory",
                        Quantity = 500,
                        IsActive = true,
                        ImagePath = "ImagePath"
                        },
                        new ProductTable { ProductNumber = 2,
                        ProductName = "ProductName2",
                        Price = 202,
                        CategoryByAge = "CategoryByAge2",
                        Category = "Category2",
                        SellCategory = "SellCategory2",
                        Quantity = 5002,
                        IsActive = false,
                        ImagePath = "ImagePath"
                        },
                   }
                };

            //    context.Wishlists.Add(Wishlist);
            //    context.SaveChanges();
            //}

            return Wishlist;
        }
    }
}

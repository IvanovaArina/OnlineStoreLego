using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.Core.DTOs;
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
            using (var context = new WishlistContext())
            {
                Wishlist = new WishlistTable
                {
                    test = 2,
                    //wishlistEntity = new List<int>()
                    //Products = new List<ProductTable>
                    //{
                    //    new ProductTable { ProductNumber = 1,
                    //    ProductName = "ProductName",
                    //    Price = 20,
                    //    CategoryByAge = "CategoryByAge",
                    //    Category = "Category",
                    //    SellCategory = "SellCategory",
                    //    Quantity = 500,
                    //    IsActive = true,
                    //    ImagePath = "ImagePath"
                    //    },
                    //    new ProductTable { ProductNumber = 2,
                    //    ProductName = "ProductName2",
                    //    Price = 202,
                    //    CategoryByAge = "CategoryByAge2",
                    //    Category = "Category2",
                    //    SellCategory = "SellCategory2",
                    //    Quantity = 5002,
                    //    IsActive = false,
                    //    ImagePath = "ImagePath"
                    //    },
                    Products = new List<int>()
                };

                context.Wishlists.Add(Wishlist);
                context.SaveChanges();

            }
        return Wishlist;
        }

        public bool CkeckIfWihlistContainItems(int wishlistId)
        {
            WishlistTable wishlistDb = null;
            using (var db = new WishlistContext())
            {
                wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);


                if (wishlistDb.Products.Count == 0)
                {
                    return false;
                }
            }

            return true;
        }

        //public WishlistTable addFirstProductToWishlist(int wishlistId, ProductTable productDb)
        //{
        //    WishlistTable wishlistDb = null;
        //    using (var db = new WishlistContext())
        //    {
        //        wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId==wishlistId);

        //        wishlistDb.Products = new List<ProductTable> {productDb};

        //        db.SaveChanges();
        //    }
        //    return wishlistDb;

        //}

        //public WishlistTable addProductToWishlist(int wishlistId, ProductTable productDb)
        //{
        //    WishlistTable wishlistDb = null;
        //    using (var db = new WishlistContext())
        //    {
        //        wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);

        //        //productDb.Count--

        //        wishlistDb.Products.Add(productDb);

        //        db.SaveChanges();
        //    }
        //    return wishlistDb;

        //}

        //public void AddToWishlistInDb(int productId, int userId)
        //{


        //    ProductTable productDb = null;
        //    using (var db = new ProductContext())
        //    {
        //        productDb = db.Products.FirstOrDefault(m => m.ProductId == productId);
        //    }

        //    UDbTable userDb = null;
        //    using (var db = new UserContext())
        //    {
        //        userDb = db.Users.FirstOrDefault(m => m.UserId == userId);

        //        if (!CkeckIfWihlistContainItems(userDb.WishlistId))
        //        {
        //            userDb.Wishlist = addFirstProductToWishlist(userDb.WishlistId, productDb);
        //            userDb.WishlistId = userDb.Wishlist.wishlistId;
        //        }
        //        else
        //        {
        //            userDb.Wishlist = addProductToWishlist(userDb.WishlistId, productDb);
        //            userDb.WishlistId = userDb.Wishlist.wishlistId;
        //        }

        //        db.SaveChanges();


        //    }

        //}


    }
}

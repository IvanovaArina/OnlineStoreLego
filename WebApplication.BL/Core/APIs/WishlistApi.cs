using AutoMapper;
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


        public WishlistTable createWishlistTableEmpty()
        {
            WishlistTable Wishlist = null;

            using (var context = new WishlistContext())
            {
                
                Wishlist = new WishlistTable
                {
                    test = 2,
                    Products = new List<int>()
                };

                context.Wishlists.Add(Wishlist);
                context.SaveChanges();

            }
          return Wishlist;
        }

        public bool checkIfProductNumberExists(int number)
        {
            try
            {
                using (var db = new ProductContext())
                {
                    var dbProduct = db.Products.FirstOrDefault(x => x.ProductNumber == number);

                    if (dbProduct != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                using (var context = new ProductContext())
                {
                    context.Database.EnsureCreated();
                }
            }
        }

        public WishlistTable createWishlistTable()
        {
            ProductApi productApi = new ProductApi();
            var product = productApi.getDefaultProductTable();

            if (!checkIfProductNumberExists(product.ProductNumber))
            {
                using (var context = new ProductContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }

           

            ProductDTO productDTO = Mapper.Map<ProductDTO>(product);

            WishlistTable wishlistTable = createWishlistTableEmpty();

            using (var context = new WishlistContext())
            {
                wishlistTable.Products.Add (productDTO.ProductId);
                context.Wishlists.Add (wishlistTable);
                context.SaveChanges();
            }

            return wishlistTable;
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

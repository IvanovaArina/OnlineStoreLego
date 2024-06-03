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

                //context.Wishlists.Add(Wishlist);
                //context.SaveChanges();

            }
            return Wishlist;
        }

        public bool checkIfProductNumberExists(ProductContext db, int number) // Принимает ProductContext как параметр
        {
            var dbProduct = db.Products.FirstOrDefault(x => x.ProductNumber == number);
            return (dbProduct != null);
        }

        //public bool checkIfProductNumberExists(int number)
        //{
        //    using (var db = new ProductContext())
        //        {
        //            var dbProduct = db.Products.FirstOrDefault(x => x.ProductNumber == number);

        //            if (dbProduct != null)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //}

        public ProductDTO createProduct()
        {
            ProductApi productApi = new ProductApi();
            var product = productApi.getDefaultProductTable();

            using (var db = new ProductContext())
            {
                if (!checkIfProductNumberExists(db, product.ProductNumber))
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }
            }

            ProductDTO productDTO = Mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public WishlistTable createWishlistTable()
        {
            ProductDTO productDTO = createProduct();
            WishlistTable wishlistTable = createWishlistTableEmpty();

            using (var context = new WishlistContext())
            {
                wishlistTable.Products.Add(productDTO.ProductId);
                context.Wishlists.Add(wishlistTable);
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


                if (wishlistDb.Products == null)
                {
                    return false;
                }
            }

            return true;
        }

        //void
        public void addFirstProductToWishlist(int wishlistId, ProductTable productDb)
        {
            WishlistTable wishlistDb = null;
            using (var db = new WishlistContext())
            {
                wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);

                wishlistDb.Products = new List<int>() { productDb.ProductId };
                //wishlistDb.Products.Add(productDb.ProductId);

                db.SaveChanges();
            }

            using (var db = new WishlistContext())
            {
                wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);
            }



                ProductTable productTable = null;
            using (var db = new ProductContext())
            {
                productTable = db.Products.FirstOrDefault(m => m.ProductId == productDb.ProductId);

                productTable.Quantity--;
                db.SaveChanges();
            }

            //return wishlistDb;

        }

        //void
        public void addProductToWishlist(int wishlistId, ProductTable productDb)
        {
            WishlistTable wishlistDb = null;
            using (var db = new WishlistContext())
            {
                wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);

                //productDb.Count--

                wishlistDb.Products.Add(productDb.ProductId);

                db.SaveChanges();
            }
            //return wishlistDb;

        }

        public void AddToWishlistInDb(int productId, int userId)
        {
            ProductTable productDb = null;
            using (var db = new ProductContext())
            {
                productDb = db.Products.FirstOrDefault(m => m.ProductId == productId);
            }

            UDbTable userDb = null;
            using (var db = new UserContext())
            {
                userDb = db.Users.FirstOrDefault(m => m.UserId == userId);

                if (!CkeckIfWihlistContainItems(userDb.WishlistId))
                {
                    addFirstProductToWishlist(userDb.WishlistId, productDb);
                }
                else
                {
                    addProductToWishlist(userDb.WishlistId, productDb);
                }
                //-
                db.SaveChanges();


            }

        }


    }
}

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


        //public WishlistTable createWishlistTableEmpty()
        //{
        //    WishlistTable Wishlist = null;

        //    using (var context = new WishlistContext())
        //    {
        //        if (!checkIfWishlistExists(context, 0))
        //        {
        //            context.Wishlists.Add(Wishlist = new WishlistTable
        //            {
        //                test = 2,
        //                Products = new List<ProductTable>()
        //            });
        //            //context.SaveChanges();
        //        }
        //        else
        //        {
        //            context.Wishlists.Add(Wishlist = new WishlistTable
        //            {
        //                test = 3,
        //                Products = new List<ProductTable>()
        //            });
        //            //context.SaveChanges();
        //        }

        //        //context.Wishlists.Add(Wishlist);
        //        context.SaveChanges();

        //    }
        //    return Wishlist;
        //}

        public bool checkIfProductNumberExists(ProductContext db, int number) 
        {
            var dbProduct = db.Products.FirstOrDefault(x => x.ProductNumber == number);
            return (dbProduct != null);
        }

        public bool checkIfWishlistTestExists(WishlistContext db, int test)
        {
            var dbWishlist = db.Wishlists.FirstOrDefault(x => x.test == test);
            return (dbWishlist != null);
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
            ProductDTO productDTO = Mapper.Map<ProductDTO>(product);

            using (var db = new ProductContext())
            {
                if (!checkIfProductNumberExists(db, product.ProductNumber))
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                    var t = db.Products.FirstOrDefault(m => m.ProductNumber == product.ProductNumber);
                    productDTO.ProductId = t.ProductId;
                

                
            }

            
              
            return productDTO;
        }

        public WishlistTable getDefaultWishlistTable()
        {
            return new WishlistTable()
            {
                test = 1,
                Products = new List<ProductTable>()
            };
        }

        public WishlistDTO createWishlist()
        {
            WishlistApi wishlistApi = new WishlistApi();
            var wishlist = wishlistApi.getDefaultWishlistTable();

            using (var db = new WishlistContext())
            {
                //if (!checkIfWishlistTestExists(db, wishlist.test))
                //{
                //    db.Wishlists.Add(wishlist);
                //    db.SaveChanges();
                //} 

                checkIfWishlistTestExists(db, wishlist.test);
                
                    db.Wishlists.Add(wishlist);
                    db.SaveChanges();
                
            }

            WishlistDTO wishlistDTO = Mapper.Map<WishlistDTO>(wishlist);
            return wishlistDTO;
        }

        public ProductTable findProductInDbById(int id)
        {
            ProductTable productTable = null;
            using (var context = new ProductContext()) {
                productTable = context.Products.FirstOrDefault(m => m.ProductId == id);
            }
            return productTable;
        }

        public WishlistTable createWishlistTable()
        {
            ProductDTO productDTO = createProduct();
            WishlistDTO wishlistDTO = createWishlist();

            WishlistTable wishlistTable = Mapper.Map<WishlistTable>(wishlistDTO);

            using (var context = new WishlistContext())
            {
                var t = findProductInDbById(productDTO.ProductId);
                wishlistTable.Products.Add(t);
                //context.Wishlists.Add(wishlistTable);
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

                wishlistDb.Products = new List<ProductTable>() { productDb};
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

                wishlistDb.Products.Add(productDb);

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

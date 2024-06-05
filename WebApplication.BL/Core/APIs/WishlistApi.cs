using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.Core.DTOs;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities;
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
                checkIfProductNumberExists(db, product.ProductNumber);
                    //if (!checkIfProductNumberExists(db, product.ProductNumber))
                //{
                //    db.Products.Add(product);
                //    db.SaveChanges();
                //}
                    //var t = db.Products.FirstOrDefault(m => m.ProductNumber == product.ProductNumber);
                    //productDTO.ProductId = t.ProductId;
                

                
            }

            
              
            return productDTO;
        }

        public WishlistTable getDefaultWishlistTable()
        {
            return new WishlistTable()
            {
                test = 1,
                Products = new List<MyInt>()
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

            //using (var context = new WishlistContext())
            //{
            //    var t = findProductInDbById(productDTO.ProductId);
            //    wishlistTable.Products.Add(t);
            //    context.SaveChanges();
            //}

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

        public void DecrementCountOfProduct(int ProductId)
        {
            ProductTable productTable = null;
            using (var db = new ProductContext())
            {
                productTable = db.Products.FirstOrDefault(m => m.ProductId == ProductId);

                productTable.Quantity--;
                db.SaveChanges();
            }
        }

        //public void addProductToWishlist(int wishlistId, ProductTable productDb)
        //{
        //    WishlistTable wishlistDb = null;
        //    using (var db = new WishlistContext())
        //    {
        //        wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);

        //        List<ProductTable> products = new List<ProductTable>();
        //        products = wishlistDb.Products;
        //        products.Add(productDb);

        //        WishlistTable newWishlistTable = new WishlistTable()
        //        {
        //            wishlistId = wishlistId,
        //            test = wishlistDb.test,
        //            Products = products,
        //        };

        //        //wishlistDb = newWishlistTable;

        //        db.Wishlists.Remove(wishlistDb);
        //        db.Wishlists.Add(newWishlistTable);

        //        db.SaveChanges();
        //    }

        //    using (var db = new WishlistContext())
        //    {
        //        wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);
        //    }

        //    DecrementCountOfProduct(productDb.ProductId);
        //}

        public void saveProduct()
        {
            using (var db = new ProductContext())
            {

            }
        }

        public void addProductToWishlist(int wishlistId, ProductTable productDb)
        {
            WishlistTable wishlistDb = null;
            using (var db = new WishlistContext())
            {
                //using (var db1 = new MyIntContext())
                //{
                    wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);

                    MyInt myInt = new MyInt()
                    {
                        ProductId = productDb.ProductId,
                        WishlistId = wishlistDb.wishlistId
                    };

                //db1.MyInts.Add(myInt);
                //db1.SaveChanges();

                wishlistDb.Products.Add(myInt);

                    db.Entry(wishlistDb).State = EntityState.Modified;

                    db.SaveChanges();
                //}
            }

            using (var db = new WishlistContext())
            {
                wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);
            }

            DecrementCountOfProduct(productDb.ProductId);
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

                //--if
                //if (!CkeckIfWihlistContainItems(userDb.WishlistId))
                //{
                //    addFirstProductToWishlist(userDb.WishlistId, productDb);
                //}
                //else
                //{
                //    addProductToWishlist(userDb.WishlistId, productDb);
                //}

                //-
                //CkeckIfWihlistContainItems(userDb.WishlistId);
                addProductToWishlist(userDb.WishlistId, productDb);
                //-
                db.SaveChanges();




            }

        }


    }
}

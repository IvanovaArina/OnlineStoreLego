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

                    context.SaveChanges();
                }
            }
        }


        //public bool checkIfProductNumberExists(ProductContext db, int number) 
        //{
        //    var dbProduct = db.Products.FirstOrDefault(x => x.ProductNumber == number);
        //    return (dbProduct != null);
        //}


        public bool checkIfWishlistTestExists(WishlistContext db, int test)
        {
            var dbWishlist = db.Wishlists.FirstOrDefault(x => x.test == test);
            return (dbWishlist != null);
        }

        //public ProductDTO createProduct()
        //{
        //    ProductApi productApi = new ProductApi();
        //    var product = productApi.getDefaultProductTable();
        //    ProductDTO productDTO = Mapper.Map<ProductDTO>(product);

        //    checkIfProductNumberExists(product.ProductNumber);

        //    return productDTO;
        //}

        public WishlistTable getDefaultWishlistTable()
        {
            return new WishlistTable()
            {
                test = 4,
                //MyInts = new List<MyInt>()
            };
        }

        public WishlistDTO createWishlist()
        {
            WishlistApi wishlistApi = new WishlistApi();
            var wishlist = wishlistApi.getDefaultWishlistTable();

            using (var db = new WishlistContext())
            {
                checkIfWishlistTestExists(db, wishlist.test);
                
                    db.Wishlists.Add(wishlist);
                    db.SaveChanges();
                
            }

            WishlistDTO wishlistDTO = Mapper.Map<WishlistDTO>(wishlist);
            return wishlistDTO;
        }



        public WishlistTable createWishlistTable()
        {
            //ProductDTO productDTO = createProduct();
          
            WishlistDTO wishlistDTO = createWishlist();

            WishlistTable wishlistTable = Mapper.Map<WishlistTable>(wishlistDTO);

            return wishlistTable;
        }

        public bool CkeckIfWihlistContainItems(int wishlistId)
        {
            using (var db = new WishlistContext())
            {
                List <MyInt> ints = db.MyInts.Where (m=> m.WishlistId == wishlistId).ToList();

                if (ints.Count == 0)
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

        public bool checkIfMyIntsContainsProductIdAndWishlistId(int wishlistId, int productId)
        {
            using(var db = new WishlistContext())
            {
                var myInt = db.MyInts.Where(m=>m.ProductId == productId & m.WishlistId==wishlistId).FirstOrDefault();
                if (myInt != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void addProductToWishlist(int wishlistId, ProductTable productDb)
        {
            WishlistTable wishlistDb = null;
            using (var db = new WishlistContext())
            {
                    wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);

                    MyInt myInt = new MyInt()
                    {
                        ProductId = productDb.ProductId,
                        Wishlist = wishlistDb 
                    };

                    wishlistDb.MyInts.Add(myInt);

                    db.Entry(wishlistDb).State = EntityState.Modified;
                                

                db.MyInts.Add(myInt);
                db.SaveChanges();

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

                if (!checkIfMyIntsContainsProductIdAndWishlistId(userDb.WishlistId, productDb.ProductId))
                {
                    addProductToWishlist(userDb.WishlistId, productDb);
                }
                             
                db.SaveChanges();
            }
        }

        public List<ProductDTO> getWishlistFromDatabase(int userId)
        {
            List<ProductDTO> listOfProductsDTO = new List<ProductDTO>();

            UDbTable userDb = null;

            using (var db = new UserContext())
            {
                userDb = db.Users.FirstOrDefault(w => w.UserId == userId);
            }

            List<MyInt> userWishlistTable = null;
            using (var db = new WishlistContext())
            {
                userWishlistTable = db.MyInts.Where(w => w.WishlistId == userDb.WishlistId).ToList();
            }

            ProductApi productApi = new ProductApi();


            if (userWishlistTable != null)
            {
                foreach (var i in userWishlistTable)
                {
                    listOfProductsDTO.Add(productApi.getProductDTObyId(i.ProductId));
                }
            }
            return listOfProductsDTO;
        }
    }
}

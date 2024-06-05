using System;
using System.Collections.Generic;
using System.Data.Entity;
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

                    context.SaveChanges();
                }
            }
        }
        public CartTable createCartTable()
        {
            CartTable Cart = null;
            using (var context = new CartContext())
            {

                Cart = new CartTable
                {
                    testCart = 55
                };

                context.Carts.Add(Cart);
                context.SaveChanges();
            }

            return Cart;
        }

        //_______________________________wishlist
        //public bool CkeckIfWihlistContainItems(int wishlistId)
        //{
        //    using (var db = new WishlistContext())
        //    {
        //        List<MyInt> ints = db.MyInts.Where(m => m.WishlistId == wishlistId).ToList();

        //        if (ints.Count == 0)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //public void DecrementCountOfProduct(int ProductId)
        //{
        //    ProductTable productTable = null;
        //    using (var db = new ProductContext())
        //    {
        //        productTable = db.Products.FirstOrDefault(m => m.ProductId == ProductId);

        //        productTable.Quantity--;
        //        db.SaveChanges();
        //    }
        //}

        public bool checkIfMyIntCartsContainsProductIdAndCartId(int cartId, int productId)
        {
            //using (var db = new WishlistContext())
            //{
            //    var myInt = db.MyInts.Where(m => m.ProductId == productId & m.WishlistId == wishlistId).FirstOrDefault();
            //    if (myInt != null)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
            return true;
        }

        public void addProductToCart(int cartId, ProductTable productDb)
        {
            //WishlistTable wishlistDb = null;
            //using (var db = new WishlistContext())
            //{
            //    wishlistDb = db.Wishlists.FirstOrDefault(m => m.wishlistId == wishlistId);

            //    MyInt myInt = new MyInt()
            //    {
            //        ProductId = productDb.ProductId,
            //        Wishlist = wishlistDb
            //    };

            //    wishlistDb.MyInts.Add(myInt);

            //    db.Entry(wishlistDb).State = EntityState.Modified;


            //    db.MyInts.Add(myInt);
            //    db.SaveChanges();

            //}

            //DecrementCountOfProduct(productDb.ProductId);
        }


        public void AddToCartInDb(int productId, int userId)
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

                if (!checkIfMyIntCartsContainsProductIdAndCartId(userDb.WishlistId, productDb.ProductId))
                {
                    addProductToCart(userDb.WishlistId, productDb);
                }

                db.SaveChanges();
            }
        }
    }
}

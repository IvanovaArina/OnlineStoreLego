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


        public bool CkeckIfCartContainItems(int cartId)
        {
            using (var db = new CartContext())
            {
                List<MyIntCart> ints = db.MyIntsCart.Where(m => m.CartId == cartId).ToList();

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

        public bool checkIfMyIntCartsContainsProductIdAndCartId(int cartId, int productId)
        {
            using (var db = new CartContext())
            {
                var myIntCart = db.MyIntsCart.Where(m => m.ProductId == productId & m.CartId == cartId).FirstOrDefault();
                return (myIntCart != null);
                
            }
        }
        
        public int getCountInCart(int cartId, int productId)
        {
            using (var db = new CartContext())
            {
                var myIntCart = db.MyIntsCart.Where(m => m.ProductId == productId & m.CartId == cartId).FirstOrDefault();
                return myIntCart.Count;
                
            }
        }

        public void addProductToCart(int cartId, ProductTable productDb)
        {
            CartTable cartDb = null;
            using (var db = new CartContext())
            {
                cartDb = db.Carts.FirstOrDefault(m => m.cartId == cartId);

                MyIntCart myIntCart = new MyIntCart()
                {
                    ProductId = productDb.ProductId,
                    Cart = cartDb
                };

                cartDb.MyIntsCart.Add(myIntCart);

                db.Entry(cartDb).State = EntityState.Modified;

                db.MyIntsCart.Add(myIntCart);
                db.SaveChanges();

            }

            DecrementCountOfProduct(productDb.ProductId);
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

       
            public List<ProductDTO> getCartFromDatabase(int userId)
        {
            List<ProductDTO> listOfProductsDTO = new List<ProductDTO>();

            UDbTable userDb = null;

            using (var db = new UserContext())
            {
                userDb = db.Users.FirstOrDefault(w => w.UserId == userId);
            }

            List<MyIntCart> userCartTable = null;
            using (var db = new CartContext())
            {
                userCartTable = db.MyIntsCart.Where(w => w.CartId == userDb.CartId).ToList();
            }

            ProductApi productApi = new ProductApi();

            if (userCartTable != null)
            {
                foreach (var i in userCartTable)
                {
                    listOfProductsDTO.Add(productApi.getProductDTObyId(i.ProductId));
                }
            }
            return listOfProductsDTO;
        }
    }
}

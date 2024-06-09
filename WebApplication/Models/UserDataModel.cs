using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;
using WebApplication.BL.Core.APIs;
using WebApplication.BL.Core.DTOs;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Enums;
using WebApplication.Domain.Entities.User;

namespace WebApplication.Models
{
    public class UserDataModel
    {
        //public UserApi userApi;

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string KeyCredential { get; set; }

        public URole Role { get; set; }
        //public string UserIp { get; set; }

        public int WishlistId { get; set; }

        public int CartId { get; set; }
        public int OrderId { get; set; }


        public UserDataModel() {
            //userApi = new UserApi();
        }

        public List<UserDTO> dataForTable()
        {
            var userApi = new UserApi();
            return userApi.getUsersFromDatabase();
        } 
        
        public List<ProductDTO> dataForTableWishlist(int userId)
        {
            var wishlistApi = new WishlistApi();
            return wishlistApi.getWishlistFromDatabase(userId);
        }  
        
        public List<ProductDTO> dataForTableCart(int userId)
        {
            var cartApi = new CartApi();
            return cartApi.getCartFromDatabase(userId);
        } 
        
        public List<OrderDTO> dataOrderForTable(int userId)
        {
            var orderApi = new OrderApi();
            return orderApi.getOrdersFromDatabase(userId);
        }  
        
        public List<OrderDTO> dataOrderForTableForAdmin()
        {
            var orderApi = new OrderApi();
            return orderApi.getdataOrderForTableForAdmin();
        } 
        
        public int getCountInCart(int cartId, int productId)
        {
            var cartApi = new CartApi();
            return cartApi.getCountInCart(cartId, productId);
        }

        public bool CkeckIfWihlistContainItems(int wishlistId)
        {
            var wishlistApi = new WishlistApi();
            return wishlistApi.CkeckIfWihlistContainItems(wishlistId);
        }

        public bool CkeckIfCartContainItems(int cartId)
        {
            var cartApi = new CartApi();
            return cartApi.CkeckIfCartContainItems(cartId);
        }

        public ProductModel getDefaultProductModel()
        {
           return new ProductModel(); 
        }    


        public UserDTO moveDataFromModelToDTO()
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = this.UserId,
                Username = this.Username,
                Email = this.Email,
                Password = this.Password,
                ConfirmPassword = this.ConfirmPassword,
                KeyCredential = this.KeyCredential,
                Role = this.Role,
                WishlistId = this.WishlistId,
                CartId = this.CartId
            };

            return userDTO;
        }

        public UserDataModel moveDataFromDTOToModel(UserDTO userDTO)
        {
            UserDataModel userModel = new UserDataModel
            {
                UserId = userDTO.UserId,
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password,
                ConfirmPassword = userDTO.ConfirmPassword,
                KeyCredential = userDTO.KeyCredential,
                Role = userDTO.Role,
                WishlistId = userDTO.WishlistId,
                CartId = userDTO.CartId
            };

            return userModel;
        }

        public UserDTO GetCurrentUser(int userId)
        {
            using (var db = new ReviewContext())
            {
                Console.WriteLine($"Looking for user with UserId: {userId}");
                var user = db.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    Console.WriteLine($"User found: {user.Username} with ID: {user.UserId}");
                    return new UserDTO
                    {
                        UserId = user.UserId,
                        Username = user.Username,
                        Email = user.Email,
                        Role = user.Role,
                        WishlistId = user.WishlistId,
                        CartId = user.CartId
                    };
                }
                else
                {
                    Console.WriteLine($"User not found in database for UserId: {userId}");
                }
            }
            return null;
        }


    }
}



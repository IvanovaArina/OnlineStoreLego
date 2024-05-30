﻿using System.Reflection.Emit;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.Enums;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }

        public string KeyCredential { get; set; }

        public URole Role { get; set; }
        //public string UserIp { get; set;}

        public WishlistTable Wishlist { get; set; }

        public CartTable Cart { get; set; }
        public OrderTable Order { get; set; }



    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.Domain.Entities.Enums;
using WebApplication.BL;
using WebApplication.Domain.Entities.User;

namespace WebApplication.Models
{
    public class UserSignIn
    {
        [Required]

        [ContainsAtSign(ErrorMessage = "Email должен содержать символ '@'.")]
        
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

       
        [Required]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "Пароль должен быть не менее 7 символов.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают.")]
        public string ConfirmPassword { get; set; }

        public URole Level { get; set; }
        public string UserIp { get; set; }


        public WishlistEntity Wishlist { get; set; }

    }
}
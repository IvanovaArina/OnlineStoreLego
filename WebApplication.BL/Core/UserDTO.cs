using System.Reflection.Emit;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.Enums;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }

        public string KeyCredential { get; set; }

        public URole Level { get; set; }
        public string UserIp { get; set;}

        public WishlistTable Wishlist { get; set; }



    }
}


using System.Reflection.Emit;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.BL.Core
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public URole Level { get; set; }
        public string UserIp { get; set;}  

    }
}


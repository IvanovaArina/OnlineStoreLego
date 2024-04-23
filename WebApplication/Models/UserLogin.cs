using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Models
{
    public class UserLogin
    {
        public int UserId { get; set; } 
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public URole Level { get; set; }
    }
}

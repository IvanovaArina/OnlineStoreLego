
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Models
{
    public class UserData
    {
        //public int UserId { get; set; }
        public int UserIp { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
       
        public string Password { get; set; }
        public URole Role { get; set; }
    }
}
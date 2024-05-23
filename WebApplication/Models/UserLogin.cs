using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Models
{
    public class UserLogin
    {
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public URole Level { get; set; }
    }
}

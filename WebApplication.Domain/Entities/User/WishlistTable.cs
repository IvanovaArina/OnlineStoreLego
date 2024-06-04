using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication.Domain.Entities.Admin;

namespace WebApplication.Domain.Entities.User
{
    public class WishlistTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wishlistId { get; set; }

        public int test { get; set; }

        public List<MyInt> Products { get; set; } = new List<MyInt>();
    }
}
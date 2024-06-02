using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Admin;

namespace WebApplication.Domain.Entities.User
{
    public class WishlistTable
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wishlistId { get; set; }

        public int test { get; set; }

        public List <int> Products { get; set; }

    }
}

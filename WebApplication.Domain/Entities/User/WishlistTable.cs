using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities.User
{
    public class WishlistTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wishlistId { get; set; }

        public int test { get; set; }


        //[Required]
        //public WishlistEntity wishlistEntity { get; set; }

        [Required]
        public List<int> wishlistEntity { get; set; }


        //[Required]
        //// Навигационное свойство 
        //public User user { get; set; }



    }
}

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


        // Навигационное свойство
        public List <ProductTable> Products { get; set; }



        //[Required]
        //public WishlistEntity wishlistEntity { get; set; }

        //[Required]
        //public List<int> wishlistEntity { get; set; }

        //[Required]
        //public WishlistEntity wishlistEntity { get; set; }

        //коллекция из ключей на товары - пользовательский тип данных?
        //List <pruductId> - Arina


        //[Required]
        //// Навигационное свойство 
        //public User user { get; set; }



    }
}

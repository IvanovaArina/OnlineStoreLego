using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.Domain.Entities.Admin
{
    public class ProductTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public int ProductNumber { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string CategoryByAge { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string SellCategory { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsActive { get; set; }


        public string ProductDetail { get; set; }



        //// Внешний ключ
        //public int WishlistId { get; set; }

        //// Навигационное свойство
        //[ForeignKey("WishlistId")]
        //public virtual WishlistTable wishlist { get; set; }


        //// Внешний ключ
        //public int CartId { get; set; }

        //// Навигационное свойство
        //[ForeignKey("CartId")]
        //public virtual CartTable cart { get; set; }


    }
}

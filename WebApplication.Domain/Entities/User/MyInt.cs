using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities.User
{
    public class MyInt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MyIntId { get; set; }

        // Внешний ключ для связи с WishlistTable
        public int? WishlistId { get; set; }

        // Навигационное свойство для связи с WishlistTable
        [ForeignKey("WishlistId")]
        public virtual WishlistTable Wishlist { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public string ImagePath { get; set; }

        // Внешний ключ для связи с WishlistTable
        public int? WishlistId { get; set; }

        // Навигационное свойство для связи с WishlistTable
        [ForeignKey("WishlistId")]
        public virtual WishlistTable Wishlist { get; set; }
    }
}

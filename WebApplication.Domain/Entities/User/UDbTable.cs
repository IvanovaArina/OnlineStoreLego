using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities.User
{
    public class UDbTable //POCO (Plain Old CLR Object), который Entity Framework использует для представления записи в таблице базы данных 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display (Name = "Username")]
        [StringLength (30, MinimumLength = 3, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "Password cannot be shorter than 7 characters.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "Password cannot be shorter than 7 characters.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }

        



        //public URole Level { get; set; }
        [Required]
        [StringLength(30)]
        public string UserIp { get; set; }

        [Required]
        //[StringLength(30)]
        public URole Role{  get; set; }


        ////foreign key to wishlist

        //[Required]
        //public WishlistTable wishlistLink { get; set; }


        ////foreign key to cart 
        //[Required]
        //public CartTable cartLink { get; set; }




        // Внешний ключ
        public int wishlistId { get; set; }

        // Навигационное свойство
        [ForeignKey("wishlistId")]
        public WishlistTable Wishlist { get; set; }

    }
}

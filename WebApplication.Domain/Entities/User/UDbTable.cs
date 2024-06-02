using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities.User
{
    public class UDbTable // POCO (Plain Old CLR Object), который Entity Framework использует для представления записи в таблице базы данных 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "Password cannot be shorter than 7 characters.")]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "Password cannot be shorter than 7 characters.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public URole Role { get; set; }

        public int WishlistId { get; set; }

        public int CartId { get; set; }

    }
}

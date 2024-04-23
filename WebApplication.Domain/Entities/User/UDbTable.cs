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
        [StringLength (30, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(50)]
        public string Phone { get; set; }



        //[Display(Name = "Date of Birth")]

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(30)]
        public string Country { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(30)]
        public string City { get; set; }

        //[DataType (DataType.Date)]
        //public DateTime LastLogin { get; set; }

        //public URole Level { get; set; }
        [Required]
        [StringLength(30)]
        public string UserIp { get; set; }

        [Required]
        //[StringLength(30)]
        public URole Role{  get; set; }
    }
}

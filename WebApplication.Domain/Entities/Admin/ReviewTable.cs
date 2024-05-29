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
    public class ReviewTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Required]
        public bool Approved { get; set; }

        [Range(0, 5)]
        [Required]
        public int Rating { get; set; }

        [Required]
        public string Text { get; set; }

        // Foreign Key for User
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UDbTable User { get; set; }

        // Foreign Key for Product
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductTable Product { get; set; }


    }

}

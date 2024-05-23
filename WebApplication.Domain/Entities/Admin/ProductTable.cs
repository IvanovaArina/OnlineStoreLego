using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double Price { get; set; }

        [Required]
        public string CategoryByAge { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string SellCategory { get; set; }


        [Required]
        public int Quantity { get; set; }

        
        public string ProductDetail { get; set; }

    }
}

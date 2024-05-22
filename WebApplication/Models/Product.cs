using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(15)]
        public string AgeCategory { get; set; }

        [Required]
        [StringLength(15)]
        public string Category { get; set; }

        [Required]
        [StringLength(15)]
        public string SellCategory { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

    }
}
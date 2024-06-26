﻿using System;
using System.Collections.Generic;
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
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}

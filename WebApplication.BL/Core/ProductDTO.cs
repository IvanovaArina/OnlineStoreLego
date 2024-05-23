using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.BL.Core
{
    public class ProductDTO
    {
       
        public int ProductId { get; set; }

        public int ProductNumber { get; set; }

        public double Price { get; set; }

        public string CategoryByAge { get; set; }

        public string Category { get; set; }

        public string SellCategory { get; set; }

        public int Quantity { get; set; }

        public string ProductDetail { get; set; }
    }
}

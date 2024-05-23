using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;

namespace WebApplication.Models
{
    public class ProductModel
    {
        public ProductApi productApi;
        public int countProducts;


        public int ProductId { get; set; }

        public int ProductNumber { get; set; }
        public string ProductName { get; set; }

        public double Price { get; set; }

        public string CategoryByAge { get; set; }

        public string Category { get; set; }

        public string SellCategory { get; set; }

        public int Quantity { get; set; }

        public string ProductDetail { get; set; }
        public bool isActive { get; set; }

        public ProductModel()
        {
            productApi = new ProductApi();
            countProducts = 100;
        }

        public List<ProductDTO> dataForTable(int count)
        {
            return productApi.getProductsFromDatabase(count);
        }

    }
}
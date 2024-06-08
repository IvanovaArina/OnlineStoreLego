using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.User;

namespace WebApplication.Models
{
    public class ProductModel
    {
        public ProductApi productApi;
        //public int countProducts;


        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Age Category is required")]
        public string CategoryByAge { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Sell Category is required")]
        public string SellCategory { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        public string ProductDetail { get; set; }

        public bool IsActive { get; set; }
        public string ImagePath { get; set; }

        //public int? WishlistId { get; set; }

        //public virtual WishlistTable Wishlist { get; set; }
        public List<ReviewDTO> Reviews { get; set; }

        public ProductModel()
        {
            productApi = new ProductApi();
            //countProducts = 100;
        }

        public List<ProductDTO> dataForTable()
        {
            return productApi.getProductsFromDatabase();
        }

        public ProductDTO MoveDataFromModelToDTO()
        {
            ProductDTO productDTO = new ProductDTO();
            productDTO.ProductId = this.ProductId;
            productDTO.ProductNumber = this.ProductNumber;
            productDTO.ProductName = this.ProductName;
            productDTO.Price = this.Price;
            productDTO.CategoryByAge = this.CategoryByAge;
            productDTO.Category = this.Category;
            productDTO.SellCategory = this.SellCategory;
            productDTO.Quantity = this.Quantity;
            productDTO.ProductDetail = this.ProductDetail;
            productDTO.IsActive = this.IsActive;
            productDTO.ImagePath = this.ImagePath;

            return productDTO;
        }

        public ProductModel MoveDataFromDTOToModel(ProductDTO productDTO)
        {
            ProductModel productDataModel = new ProductModel();
            productDataModel.ProductId = productDTO.ProductId;
            productDataModel.ProductNumber = productDTO.ProductNumber;
            productDataModel.ProductName = productDTO.ProductName;
            productDataModel.Price = productDTO.Price;
            productDataModel.CategoryByAge = productDTO.CategoryByAge;
            productDataModel.Category = productDTO.Category;
            productDataModel.SellCategory = productDTO.SellCategory;
            productDataModel.Quantity = productDTO.Quantity;
            productDataModel.ProductDetail = productDTO.ProductDetail;
            productDataModel.IsActive = productDTO.IsActive;
            productDataModel.ImagePath = productDTO.ImagePath;

            return productDataModel;
        }
    }

}

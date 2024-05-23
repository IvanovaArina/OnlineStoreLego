using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;

namespace WebApplication.BL.Core
{
    public class ProductApi
    {
        public ProductDTO getProductDTObyNumber(int number)
        {
            ProductDTO local = null;
            using (var db = new ProductContext())
            {
                var dbProduct = db.Articles.FirstOrDefault(x => x.ProductNumber == number);
                if (dbProduct != null)
                {
                    local = new ProductDTO
                    {
                        ProductId = dbProduct.ProductId,
                        ProductNumber = dbProduct.ProductNumber,
                        ProductName = dbProduct.ProductName,
                        Price = dbProduct.Price,
                        CategoryByAge = dbProduct.CategoryByAge,
                        Category = dbProduct.Category,
                        SellCategory = dbProduct.SellCategory,
                        Quantity = dbProduct.Quantity,
                        ProductDetail = dbProduct.ProductDetail,
                        IsActive = dbProduct.isActive
                        
                    };
                }
            }

            return local;
        }


        public List<ProductDTO> getProductsFromDatabase(int productCount)
        {
            List<ProductDTO> listOfProductDTO = new List<ProductDTO>();

            for (int i = 0; i < productCount; i++)
            {

                listOfProductDTO.Add(getProductDTObyNumber(i));

            }

            return listOfProductDTO;

        }
    }
}

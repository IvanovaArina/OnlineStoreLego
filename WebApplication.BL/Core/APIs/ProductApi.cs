using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.Responces;

namespace WebApplication.BL.Core
{
    public class ProductApi
    {
        public int getProductIdByNumber(int number)
        {
            int productId = 0;

            using (var db = new ProductContext())
            {
                var article = db.Products.FirstOrDefault(x => x.ProductNumber == number);
                productId = article.ProductId;
            }

            return productId;
        }

        public ProductDTO getProductDTObyId(int id)
        {
            ProductDTO local = null;
            using (var db = new ProductContext())
            {
                var dbProduct = db.Products.FirstOrDefault(x => x.ProductId == id);
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
                        IsActive = dbProduct.IsActive
                    };
                }
            }

            return local;
        }



        public List<ProductDTO> getProductsFromDatabase()
        {
            List<ProductDTO> listOfProductDTO = new List<ProductDTO>();

            List<int> productIds = new List<int>();

            using (var db = new ProductContext())
            {
                productIds = db.Products.Select(w => w.ProductId).ToList();
            }

            foreach (var i in productIds)
            {
                listOfProductDTO.Add(getProductDTObyId(i));
            }

            return listOfProductDTO;

        }

        public bool checkIfProductNumberExists(int number)
        {
            using (var db = new ProductContext())
            {
                var dbProduct = db.Products.FirstOrDefault(x => x.ProductNumber == number);

                if (dbProduct != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void saveChanges(ProductTable productDb)
        {
            using (var db = new ProductContext())
            {
                db.Products.Add(productDb);
                try
                {
                    // Попытка сохранить изменения в базе данных
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                    // Здесь можно выбросить более общее исключение или обработать ошибку
                    throw; // Перебрасывает исключение дальше
                }
            }
        }

        public BaseResponces addProductToDb(ProductDTO productDTO)
        {
            if (checkIfProductNumberExists(productDTO.ProductNumber))
            {
                return new BaseResponces { Status = false, StatusMessage = "This Product Number already exists" };
            }

            var productDb = Mapper.Map<ProductTable>(productDTO);

            saveChanges(productDb);

            return new BaseResponces { Status = true };

        }

        private void editItemInDb(ProductDTO productDTO)
        {
            using (var context = new ProductContext())
            {
                // Находим продукт по его идентификатору (ID)
                var productDb = context.Products.FirstOrDefault(p => p.ProductNumber == productDTO.ProductNumber);

                if (productDb != null)
                {
                    // Меняем свойства продукта
                    productDb.ProductNumber = productDTO.ProductNumber;
                    productDb.ProductName = productDTO.ProductName;
                    productDb.Price = productDTO.Price;
                    productDb.CategoryByAge = productDTO.CategoryByAge;
                    productDb.Category = productDTO.Category;
                    productDb.SellCategory = productDTO.SellCategory;
                    productDb.Quantity = productDTO.Quantity;
                    productDb.ProductDetail = productDb.ProductDetail;
                    productDb.IsActive = productDTO.IsActive;

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }

            }
        }

        public void editProductInDb(ProductDTO productDTO)
        {
            if (!checkIfProductNumberExists(productDTO.ProductNumber))
            {
                addProductToDb(productDTO);
            }
            else
            {
                editItemInDb(productDTO);
            }

            //var articleDb = Mapper.Map<ArticleTable>(articleDTO);

            //saveChanges(articleDb);
        }


        public void deleteProduct(int number)
        {
            using (var context = new ProductContext())
            {


                // Найти продукт по его идентификатору 
                var articleDb = context.Products.FirstOrDefault(p => p.ProductNumber == number);

                if (articleDb != null)
                {
                    // Удаляем продукт из контекста данных
                    context.Products.Remove(articleDb);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }
            }

        }
    }
}

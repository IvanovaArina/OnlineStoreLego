using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.Core.DTOs;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core.APIs
{
    public class OrderApi
    {
        public OrderTable getDefaultOrderTable()
        {
            return new OrderTable()
            {
                testOrder = 1,
            };
        }

        public bool checkIfOrderTestExists(OrderContext db, int testOrder)
        {
            var dbOrder = db.Orders.FirstOrDefault(x => x.testOrder == testOrder);
            return (dbOrder != null);
        }

        public OrderDTO createOrder()
        {
            OrderApi orderApi = new OrderApi();
            var order = orderApi.getDefaultOrderTable();

            using (var db = new OrderContext())
            {
                checkIfOrderTestExists(db, order.testOrder);

                db.Orders.Add(order);
                db.SaveChanges();

            }

            var orderDTO = Mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public OrderTable createOrderTable()
        {
            OrderDTO orderDTO = createOrder();

            OrderTable orderTable = Mapper.Map<OrderTable>(orderDTO);

            return orderTable;
        }

        //public int saveOrderTable(OrderTable orderTable)
        //{
        //    using(var db = new OrderContext())
        //    {
        //        db.Orders.Add(orderTable);
        //        db.SaveChanges();
        //    }

        //    return orderTable.orderId;
        //}

        public int getValidOrderNumber(int userId)
        {
            int orderNumber = 0;

            using(var db = new OrderContext())
            {
                var allOrdersThisUser = db.Orders.Where(m => m.userId == userId).ToList();
           
                foreach (var order in allOrdersThisUser)
                {
                    if (orderNumber < order.orderNumber)
                    {
                        orderNumber = order.orderNumber;
                    }
                }
                        
            }

            return orderNumber;
        }

        public void SaveOrderDetails(OrderDTO orderDTO, int orderId, int userId)
        {
            var orderApi = new OrderApi();
            using(var db = new OrderContext())
            {
                var orderDb = db.Orders.FirstOrDefault(m=>m.orderId == orderId);
                orderDb.testOrder = orderDTO.testOrder;
                orderDb.FirstName = orderDTO.FirstName;
                orderDb.LastName = orderDTO.LastName;
                orderDb.Email = orderDTO.Email;
                orderDb.PhoneNumber = orderDTO.PhoneNumber;
                orderDb.Country = orderDTO.Country;
                orderDb.ShippingAddress = orderDTO.ShippingAddress;
                orderDb.MyIntsOrder = orderDTO.MyIntsOrder;
                orderDb.orderNumber = (orderApi.getValidOrderNumber(userId))+1;
                orderDb.userId = orderDTO.userId;

                db.SaveChanges();
            }
        }


        public int AddOrderInDb(int cartId)
        {
            int orderId = (createOrderTable()).orderId;
            using (var orderContext = new OrderContext())
            {
                using (var cartContext = new CartContext())
                {
                    var listOfMyIntsCart = cartContext.MyIntsCart.Where(m => m.CartId == cartId).ToList();

                    var listOfMyIntsOrder = new List<MyIntOrder>();

                    foreach (var item in listOfMyIntsCart)
                    {
                        var order = orderContext.Orders.FirstOrDefault(m => m.orderId == orderId);
                        MyIntOrder myIntOrder = new MyIntOrder()
                        {
                            ProductId = item.ProductId,
                            Count = item.Count,
                            Order = order,
                            OrderId = orderId
                        };

                        orderContext.MyIntsOrder.Add(myIntOrder);
                        orderContext.SaveChanges();

                    }

                    DecrementCountOfProduct(listOfMyIntsCart);
                    CleanCart(listOfMyIntsCart);
                 }
            }
            return orderId;
        }


        public void DecrementCountOfProduct (List<MyIntCart> listOfMyIntsCart)
        {            
            ProductTable productTable = null;
            using (var cartContext = new CartContext())
            {
                using (var db = new ProductContext())
                {
                    foreach (var item in listOfMyIntsCart)
                    {
                        var myIntCart = cartContext.MyIntsCart.FirstOrDefault(m => m.ProductId == item.ProductId & m.CartId == item.CartId);
                   
                        productTable = db.Products.FirstOrDefault(m => m.ProductId == myIntCart.ProductId);
                        productTable.Quantity -= item.Count;
                        db.SaveChanges();
                    }
                }
            }
        }

        public void CleanCart(List<MyIntCart> listOfMyIntsCart)
        {
            using (var cartContext = new CartContext())
            {
                foreach (var item in listOfMyIntsCart)
                {
                    var myIntCart = cartContext.MyIntsCart.FirstOrDefault(m => m.ProductId == item.ProductId & m.CartId == item.CartId);
                    cartContext.MyIntsCart.Remove(myIntCart);
                    cartContext.SaveChanges();
                }
            }
        }       
        
        public List<OrderDTO> getdataOrderForTableForAdmin()
        {
            var listOfAllOrders = new List<OrderDTO>();
            using (var orderContext = new OrderContext())
            {
                var orders = orderContext.Orders.Select(m=>m.orderId).ToList();

                foreach (var order in orders)
                {
                    listOfAllOrders.Add(getOrderDTOById(order));
                }

            }

            return listOfAllOrders;
        } 


        
        public List<OrderDTO> getOrdersFromDatabase(int userId)
        {
            var listOfOrders = new List<OrderDTO>();
            using (var orderContext = new OrderContext())
            {
                var orders = orderContext.Orders.Where(m=>m.userId == userId).ToList();

                foreach (var order in orders)
                {
                    listOfOrders.Add(Mapper.Map<OrderDTO>(order));
                }

            }

            return listOfOrders;
        }

        public Dictionary<ProductDTO, int> getProductsFromMyIntOrder (Dictionary<MyIntOrderDTO, int> DictionaryOfMyIntOrderDTOAndCount)
        {
            var dictionaryProductsDTO = new Dictionary<ProductDTO, int>();
            var dictionaryProductsIdsAndCount = new Dictionary<int, int>();
            
            foreach (var product in DictionaryOfMyIntOrderDTOAndCount)
            {
                dictionaryProductsIdsAndCount.Add(product.Key.ProductId, product.Value);
            }

            var productApi = new ProductApi();
            foreach (var id in dictionaryProductsIdsAndCount)
            {
                dictionaryProductsDTO.Add(productApi.getProductDTObyId(id.Key), id.Value);
            }

            return dictionaryProductsDTO;
        }
        
        public Dictionary<ProductDTO, int> getProductsFromOrder(int orderId)
        {
            var DictionaryOfMyIntOrderDTOAndCount = new Dictionary<MyIntOrderDTO, int>();
            using (var orderContext = new OrderContext())
            {
                var prodtsFromOrder = orderContext.MyIntsOrder.Where(m => m.OrderId == orderId).ToList();

                foreach (var product in prodtsFromOrder)
                {
                    DictionaryOfMyIntOrderDTOAndCount.Add(Mapper.Map<MyIntOrderDTO>(product), product.Count);
                }

            }

            return getProductsFromMyIntOrder(DictionaryOfMyIntOrderDTOAndCount);
        }

        public OrderDTO getOrderDTOById (int orderId)
        {
            OrderDTO orderDTO = null;
            using(var orderContext = new OrderContext())
            {
                var orderDb = orderContext.Orders.FirstOrDefault(m=>m.orderId == orderId);
                orderDTO = Mapper.Map<OrderDTO>(orderDb);
            }
            return orderDTO;
        }


        }
}
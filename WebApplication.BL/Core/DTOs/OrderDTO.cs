using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core.DTOs
{
    public class OrderDTO
    {
        public int orderId { get; set; }

        public int testOrder { get; set; }

        public int userId { get; set; }
        public int orderNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string ShippingAddress { get; set; }

        public List<MyIntOrder> MyIntsOrder { get; set; } = new List<MyIntOrder>();
    }
}
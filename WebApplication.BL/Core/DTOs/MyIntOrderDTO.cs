using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core.DTOs
{
    public class MyIntOrderDTO
    {
        public int MyIntOrderId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }

        // Внешний ключ для связи с OrderTable
        public int? OrderId { get; set; }

        // Навигационное свойство для связи с OrderTable
        //[ForeignKey("OrderId")]
        public virtual OrderTable Order { get; set; }
    }
}

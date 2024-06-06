using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities.User
{
    public class MyIntOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MyIntOrderId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }

        // Внешний ключ для связи с OrderTable
        public int? OrderId { get; set; }

        // Навигационное свойство для связи с OrderTable
        [ForeignKey("OrderId")]
        public virtual OrderTable Order { get; set; }

    }
}

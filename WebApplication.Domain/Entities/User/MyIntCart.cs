using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities.User
{
    public class MyIntCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MyIntCartId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }

        // Внешний ключ для связи с CartTable
        public int? CartId { get; set; }

        // Навигационное свойство для связи с CartTable
        [ForeignKey("CartId")]
        public virtual CartTable Cart { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Admin;

namespace WebApplication.Domain.Entities.User
{
    public class OrderTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }

        public int testOrder { get; set; }

        public int UserId { get; set; }

        public Dictionary<int, int> Products { get; set; }



        public List<MyIntOrder> MyIntsOrder { get; set; } = new List<MyIntOrder>();


    }
}

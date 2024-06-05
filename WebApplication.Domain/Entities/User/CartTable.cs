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
    public class CartTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cartId { get; set; }

        public int testCart { get; set; }

        public List<MyIntCart> MyIntsCart { get; set; } = new List<MyIntCart>();

    }
}

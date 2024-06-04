using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities;

namespace WebApplication.BL.Core.DTOs
{
    public class WishlistDTO
    {
        public int wishlistId { get; set; }

        public int test { get; set; }

        public MyIntIds Products { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.DBModel
{
    public class WishlistContext: DbContext
    {
        public WishlistContext() : base("WebApp")
        { }

        public virtual DbSet<WishlistTable> Wishlists { get; set; }
    }
}

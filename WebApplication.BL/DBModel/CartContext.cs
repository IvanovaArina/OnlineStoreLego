using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.DBModel
{
    public class CartContext : DbContext
    {
        public CartContext(): base("WebApp")
        { }

        public virtual DbSet<CartTable> Carts { get; set; }
        public virtual DbSet<MyIntCart> MyIntsCart { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyIntCart>()
                .HasOptional(p => p.Cart)
                .WithMany(w => w.MyIntsCart)
                .HasForeignKey(p => p.CartId);

            base.OnModelCreating(modelBuilder);
        }

    }
}

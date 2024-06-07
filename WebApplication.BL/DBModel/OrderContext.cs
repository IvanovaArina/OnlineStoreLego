using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.DBModel
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("WebApp")
        { }

        public virtual DbSet<OrderTable> Orders { get; set; }

        public virtual DbSet<MyIntOrder> MyIntsOrder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyIntOrder>()
                .HasOptional(p => p.Order)
                .WithMany(w => w.MyIntsOrder)
                .HasForeignKey(p => p.OrderId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
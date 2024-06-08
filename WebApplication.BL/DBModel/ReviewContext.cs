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
    public class ReviewContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductTable> Products { get; set; }
        public DbSet<UDbTable> Users { get; set; }
        public ReviewContext() : base("WebApp")
        { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId);

            
        }
    }
}

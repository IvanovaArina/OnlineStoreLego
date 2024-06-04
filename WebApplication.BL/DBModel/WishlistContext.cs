using System.Data.Entity;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.DBModel
{
    public class WishlistContext : DbContext
    {
        public WishlistContext() : base("WebApp")
        { }

        public virtual DbSet<WishlistTable> Wishlists { get; set; }
        //public virtual DbSet<ProductTable> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTable>()
                .HasOptional(p => p.Wishlist)
                .WithMany(w => w.Products)
                .HasForeignKey(p => p.WishlistId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

using System.Data.Entity;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.DBModel
{
    public class WishlistContext : DbContext
    {
        public WishlistContext() : base("WebApp")
        { }

        public virtual DbSet<WishlistTable> Wishlists { get; set; }
        public virtual DbSet<MyInt> MyInts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyInt>()
                .HasOptional(p => p.Wishlist)
                .WithMany(w => w.MyInts)
                .HasForeignKey(p => p.WishlistId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

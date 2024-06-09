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
    public class ProductContext: DbContext
    {
        public ProductContext() : base("WebApp")
        { }

        public virtual DbSet<ProductTable> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        

    }
}

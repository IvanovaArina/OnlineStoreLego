using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Admin;

namespace WebApplication.BL.DBModel
{
    internal class ReviewContext : DbContext
    {
        public ReviewContext() : base("WebApp")
        { }

        public virtual DbSet<ReviewTable> Reviews { get; set; }
    }
}

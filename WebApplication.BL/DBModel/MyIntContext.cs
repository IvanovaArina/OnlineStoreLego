using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.DBModel
{
    public class MyIntContext : DbContext
    {
        public MyIntContext() : base("WebApp")
        { }

        public virtual DbSet<MyInt> MyInts { get; set; }
    }
}

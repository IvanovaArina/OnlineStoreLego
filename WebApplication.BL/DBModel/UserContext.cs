using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext()
        : base ("WebApp") 
        { }

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}

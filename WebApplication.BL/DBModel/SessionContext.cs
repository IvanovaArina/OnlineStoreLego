using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;
namespace WebApplication.BL.DBModel
{
    public class SessionContext:DbContext
    {
        public SessionContext() : base("WebApp")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}

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
    internal class ArticleContext : DbContext
    {
        public ArticleContext(): base("WebApp")
        { }

        public virtual DbSet<ArticleTable> Articles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Admin;

namespace WebApplication.BL.DBModel
{
    public class NewArticleContext : DbContext
    {
        public NewArticleContext() : base("WebApp")
        { }

        public virtual DbSet<ArticleTable> Articles { get; set; }

    }

}

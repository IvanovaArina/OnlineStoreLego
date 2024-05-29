using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.BL.Core
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }

        public int ArticleNumber { get; set; }

        public string ArticleName { get; set; }
 
        //public DateTime PublishedDate { get; set; }
  
        public string Category { get; set; }
        public string AuthorName { get; set; }

        public string TextOfArticle { get; set; }




    }
}

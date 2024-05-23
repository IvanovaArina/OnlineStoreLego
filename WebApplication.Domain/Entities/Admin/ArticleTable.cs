using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities.Admin
{
    public class ArticleTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }

        [Required]
        public int ArticleNumber { get; set; }

        [Required]
        public string ArticleName { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string TextOfArticle { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;
/*using WebApplication.BL.Models;*/

namespace WebApplication.Models
{
    public class ArticleDataModel
    {
        public ArticleApi articleApi;
        public int countArticles;



        public int ArticleId { get; set; }

        public int ArticleNumber { get; set; }

        public string ArticleName { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Category { get; set; }
        public string AuthorName { get; set; }

        public string TextOfArticle { get; set; }


        public ArticleDataModel()
        {
            articleApi = new ArticleApi();
            countArticles = 100;
        }

        public List<ArticleDTO> dataForTable(int count)
        {
            return articleApi.getArticlesFromDatabase(count);
        }


    }
}
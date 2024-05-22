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

        public ArticleDataModel()
        {
            articleApi = new ArticleApi();
            countArticles = 5;
        }

        public List<ArticleDTO> dataForTable(int count)
        {
            return articleApi.getArticlesFromDatabase(count);
        }


    }
}
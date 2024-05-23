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

        public ArticleDTO moveDataFromModelToDTO()
        {
            ArticleDTO articleDTO = new ArticleDTO();
            articleDTO.ArticleId = this.ArticleId;
            articleDTO.ArticleNumber = this.ArticleNumber;
            articleDTO.AuthorName = this.AuthorName;
            articleDTO.ArticleName = this.ArticleName;
            articleDTO.TextOfArticle = this.TextOfArticle;
            //articleDTO.PublishedDate = this.PublishedDate;
            articleDTO.Category = this.Category;

            return articleDTO;
        }

    }
}
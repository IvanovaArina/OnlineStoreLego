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
        }

        public List<ArticleDTO> dataForTable()
        {
            return articleApi.getArticlesFromDatabase();
        }

        public ArticleDTO moveDataFromModelToDTO()
        {
            ArticleDTO articleDTO = new ArticleDTO();
            articleDTO.ArticleId = this.ArticleId;
            articleDTO.ArticleNumber = this.ArticleNumber;
            articleDTO.AuthorName = this.AuthorName;
            articleDTO.ArticleName = this.ArticleName;
            articleDTO.TextOfArticle = this.TextOfArticle;
            articleDTO.Category = this.Category;

            return articleDTO;
        }

        public ArticleDataModel moveDataFromDTOToModel(ArticleDTO articleDTO)
        {
            ArticleDataModel articleDataModel = new ArticleDataModel();
            articleDataModel.ArticleId = articleDTO.ArticleId;
            articleDataModel.ArticleNumber = articleDTO.ArticleNumber;
            articleDataModel.AuthorName = articleDTO.AuthorName;
            articleDataModel.ArticleName = articleDTO.ArticleName;
            articleDataModel.TextOfArticle = articleDTO.TextOfArticle;
            articleDataModel.Category = articleDTO.Category;

            return articleDataModel;
        }



    }
}
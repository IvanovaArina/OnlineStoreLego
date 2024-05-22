using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;

namespace WebApplication.BL.Core
{
    public class ArticleApi
    {


        public ArticleDTO getArticleDTObyNumber(int number)
        {
            ArticleDTO local = null;
            using (var db = new ArticleContext())
            {
                var dbArticle = db.Articles.FirstOrDefault(x => x.ArticleNumber == number);
                if (dbArticle != null)
                {
                    local = new ArticleDTO
                    {
                        ArticleId = dbArticle.ArticleId,
                        ArticleNumber = dbArticle.ArticleNumber,
                        ArticleName = dbArticle.ArticleName,
                        PublishedDate = dbArticle.PublishedDate,
                        Category = dbArticle.Category,
                        AuthorName = dbArticle.AuthorName,
                        TextOfArticle = dbArticle.TextOfArticle
                    };
                }
            }

            return local;
        }


      /*  public Tuple<int, string, string, string> getDataFromDatabase()
        {

        }*/


        //public Tuple<int, string, string, string> fromArticleDTOtoTuple(ArticleDTO articleDTO)
        //{
        //    Tuple<int, string, string, string> tuple = new Tuple<int, string, string, string>();

        //    tuple.Create()

        //}

        public List<ArticleDTO> getArticlesFromDatabase(int articlesCount)
        {
            List <ArticleDTO> listOfArticleDTO = new List <ArticleDTO>();

            for (int i=0; i< articlesCount; i++)
            {

                listOfArticleDTO.Add(getArticleDTObyNumber(i));

            }

            return listOfArticleDTO;

        }





    }
}

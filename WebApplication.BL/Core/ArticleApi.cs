﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.Enums;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core
{
    public class ArticleApi
    {


        public ArticleDTO getArticleDTObyNumber(int number)
        {
            ArticleDTO local = null;
            using (var db = new NewArticleContext())
            {
                var dbArticle = db.Articles.FirstOrDefault(x => x.ArticleNumber == number);
                if (dbArticle != null)
                {
                    local = new ArticleDTO
                    {
                        ArticleId = dbArticle.ArticleId,
                        ArticleNumber = dbArticle.ArticleNumber,
                        ArticleName = dbArticle.ArticleName,
                        //PublishedDate = dbArticle.PublishedDate,
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


        private bool checkIfArticleNumberExists(ArticleDTO articleDTO)
        {
            using (var db = new NewArticleContext())
            {
                var dbArticle = db.Articles.FirstOrDefault(x => x.ArticleNumber == articleDTO.ArticleNumber);

                if (dbArticle != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        } 

        private void saveChanges(ArticleTable articleDb)
        {
            using (var db = new NewArticleContext())
            {
                db.Articles.Add(articleDb);
                try
                {
                    // Попытка сохранить изменения в базе данных
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                    // Здесь можно выбросить более общее исключение или обработать ошибку
                    throw; // Перебрасывает исключение дальше
                }
            }
        }




        public BaseResponces addArticleToDb(ArticleDTO articleDTO)
        {
            if (checkIfArticleNumberExists(articleDTO))
            {
                return new BaseResponces { Status = false, StatusMessage = "This Article Number already exists" };
            }
                    
            var articleDb = Mapper.Map<ArticleTable>(articleDTO);

            saveChanges(articleDb);

            return new BaseResponces { Status = true };
        }



    }
}

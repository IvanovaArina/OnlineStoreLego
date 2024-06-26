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
        public int getArticleIdByNumber(int number)
        {
            int articleId = 0;

            using (var db = new NewArticleContext())
            {
                var article = db.Articles.FirstOrDefault(x => x.ArticleNumber == number);
                articleId = article.ArticleId;
            }

            return articleId;
        }

        public ArticleDTO getArticleDTObyId(int id)
        {
            ArticleDTO local = null;
            using (var db = new NewArticleContext())
            {
                var dbArticle = db.Articles.FirstOrDefault(x => x.ArticleId == id);
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
                        TextOfArticle = dbArticle.TextOfArticle,
                        ImagePath = dbArticle.ImagePath

                    };
                }
            }

            return local;
        }


        public List<ArticleDTO> getArticlesFromDatabase()
        {
            List<ArticleDTO> listOfArticleDTO = new List<ArticleDTO>();

            List <int> articleIds = new List<int>();

            using (var db = new NewArticleContext())
            {
                articleIds = db.Articles.Select(w => w.ArticleId).ToList();
            }

            foreach (var i in articleIds)
            {
                listOfArticleDTO.Add(getArticleDTObyId(i));
            }

            return listOfArticleDTO;
        }


        public bool checkIfArticleNumberExists(int number)
        {
            using (var db = new NewArticleContext())
            {
                var dbArticle = db.Articles.FirstOrDefault(x => x.ArticleNumber == number);

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
            if (checkIfArticleNumberExists(articleDTO.ArticleNumber))
            {
                return new BaseResponces { Status = false, StatusMessage = "This Article Number already exists" };
            }

            var articleDb = Mapper.Map<ArticleTable>(articleDTO);

            saveChanges(articleDb);

            return new BaseResponces { Status = true };
        }

        public bool editItemInDb(ArticleDTO articleDTO)
        {
            try
            {
                using (var context = new NewArticleContext())
                {
                    var article = context.Articles.FirstOrDefault(a => a.ArticleNumber == articleDTO.ArticleNumber);
                    if (article != null)
                    {
                        // Обновление полей статьи
                        article.ArticleName = articleDTO.ArticleName;
                        article.Category = articleDTO.Category;
                        article.AuthorName = articleDTO.AuthorName;
                        article.TextOfArticle = articleDTO.TextOfArticle;
                        article.ImagePath = articleDTO.ImagePath;

                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false; // Статья не найдена
                    }
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Error updating article: {ex.Message}");
                return false;
            }
        }

        public void editArticleInDb(ArticleDTO articleDTO)
        {
            if (!checkIfArticleNumberExists(articleDTO.ArticleNumber))
            {
                addArticleToDb(articleDTO);
            }
            else
            {
                editItemInDb(articleDTO);
            }

            //var articleDb = Mapper.Map<ArticleTable>(articleDTO);

            //saveChanges(articleDb);
        }


        public void deleteArticle(int number)
        {
            using (var context = new NewArticleContext())
            {
                              
               
                    // Найти продукт по его идентификатору 
                    var articleDb = context.Articles.FirstOrDefault(p => p.ArticleNumber == number);

                if (articleDb != null)
                {
                    // Удаляем продукт из контекста данных
                    context.Articles.Remove(articleDb);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }
            }

        }
    }
}

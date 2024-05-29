using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;
using Microsoft.Ajax.Utilities;
using System.Diagnostics;
using WebApplication.Domain.Entities.Admin;

namespace WebApplication.BL.Core
{
    public class ReviewApi
    {
        public ReviewDTO getReviewDTObyId(int number)
        {
            ReviewDTO local = null;
            using (var db = new ReviewContext())
            {
                var dbProduct = db.Reviews.FirstOrDefault(x => x.ReviewId == number);
                if (dbProduct != null)
                {
                    local = new ReviewDTO
                    {
                        ReviewId = dbProduct.ReviewId,
                        Approved = dbProduct.Approved,
                        Rating = dbProduct.Rating,
                        Text = dbProduct.Text,
                        //User = dbProduct.User,
                        //Product = dbProduct.Product,

                    };
                }
            }

            return local;
        }

        public List<ReviewDTO> getApprovedReviewsFromDatabase()
        {
            List<ReviewDTO> listOfReviewDTO = new List<ReviewDTO>();

            using (var db = new ReviewContext())
            {
                listOfReviewDTO = db.Reviews
                                    .Where(x => x.Approved)  // Фильтруем только одобренные отзывы
                                    .Select(x => new ReviewDTO
                                    {
                                        ReviewId = x.ReviewId,
                                        //Product = x.Product,
                                        Approved = x.Approved,
                                        //User = x.User,
                                        Rating = x.Rating,
                                        Text = x.Text
                                    })
                                    .ToList();
            }

            return listOfReviewDTO;
        }


        public List<ReviewDTO> getPendingReviewsFromDatabase()
        {
            List<ReviewDTO> listOfReviewDTO = new List<ReviewDTO>();

            using (var db = new ReviewContext())
            {
                listOfReviewDTO = db.Reviews
                                    .Where(x => !x.Approved)  // Фильтруем только одобренные отзывы
                                    .Select(x => new ReviewDTO
                                    {
                                        ReviewId = x.ReviewId,
                                        //Product = x.Product,
                                        Approved = x.Approved,
                                        //User = x.User,
                                        Rating = x.Rating,
                                        Text = x.Text
                                    })
                                    .ToList();
            }

            return listOfReviewDTO;
        }

        public List<ReviewDTO> getAllReviewsFromDatabase()
        {
            List<ReviewDTO> listOfReviewDTO = new List<ReviewDTO>();

            List<int> reviewIds = new List<int>();

            using (var db = new ReviewContext())
            {
                reviewIds = db.Reviews.Select(w => w.ReviewId).ToList();
            }

            foreach (var i in reviewIds)
            {

                listOfReviewDTO.Add(getReviewDTObyId(i));

            }

            return listOfReviewDTO;
        }

        public bool checkIfReviewIdExists(int id)
        {
            using (var db = new ReviewContext())
            {
                var dbReview = db.Reviews.FirstOrDefault(x => x.ReviewId == id);

                if (dbReview != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void deleteReview(int id)
        {
            using (var context = new ReviewContext())
            {


                // Найти продукт по его идентификатору 
                var reviewDb = context.Reviews.FirstOrDefault(p => p.ReviewId == id);

                if (reviewDb != null)
                {
                    // Удаляем продукт из контекста данных
                    context.Reviews.Remove(reviewDb);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }
            }

        }

        public void changeStatusOnApproved(int id)
        {
            using (var context = new ReviewContext())
            {
                var reviewDb = context.Reviews.FirstOrDefault(p => p.ReviewId == id);
                if (reviewDb != null)
                {
                    reviewDb.Approved = true;

                    context.SaveChanges();
                }
            }
        }

    }
}


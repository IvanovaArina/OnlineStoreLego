using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Domain.Entities.User;
using WebApplication.BL.DBModel;

namespace WebApplication.BL.Core
{
    public class ReviewApi
    {
        public List<ReviewDTO> GetReviewsByProductId(int productId)
        {
            using (var db = new ReviewContext())
            {
                return db.Reviews
                    .Where(x => x.ProductId == productId)
                    .Select(x => new ReviewDTO
                    {
                        ReviewId = x.ReviewId,
                        ProductId = x.ProductId,
                        UserName = x.UserName,
                        Rating = x.Rating,
                        Text = x.Text,
                        Approved = x.Approved,
                        CreatedAt = x.CreatedAt,
                        ProductName = x.Product.ProductName // Assuming you have a navigation property for Product
                    })
                    .ToList();
            }
        }

        public void AddReview(ReviewDTO reviewDto)
        {
            using (var db = new ReviewContext())
            {
                try
                {
                    var review = new Review
                    {
                        ProductId = reviewDto.ProductId,
                        UserName = reviewDto.UserName, // Обновляем для использования нового поля
                      
                        Rating = reviewDto.Rating,
                        Text = reviewDto.Text,
                        Approved = false // Отзывы требуют одобрения
                    };
                    db.Reviews.Add(review);
                    db.SaveChanges();
                    Console.WriteLine("Review added successfully");
                }
                catch (Exception ex)
                {
                    // Логирование ошибки
                    Console.WriteLine("Error occurred while adding review: " + ex.Message);
                    throw;
                }
            }
        }


        public ReviewDTO getReviewDTObyId(int number)
        {
            ReviewDTO local = null;
            using (var db = new ReviewContext())
            {
                var dbReview = db.Reviews.FirstOrDefault(x => x.ReviewId == number);
                if (dbReview != null)
                {
                    local = new ReviewDTO
                    {
                        ReviewId = dbReview.ReviewId,
                        Approved = dbReview.Approved,
                        Rating = dbReview.Rating,
                        Text = dbReview.Text,
                        ProductId = dbReview.ProductId,
                        //UserId = dbReview.UserId
                    };
                }
            }

            return local;
        }
        public List<ReviewDTO> getPendingReviewsFromDatabase()
        {
            using (var db = new ReviewContext())
            {
                return db.Reviews
                    .Where(x => !x.Approved)
                    .Select(x => new ReviewDTO
                    {
                        ReviewId = x.ReviewId,
                        ProductId = x.ProductId,
                        UserName = x.UserName,
                        Rating = x.Rating,
                        Text = x.Text,
                        Approved = x.Approved,
                        CreatedAt = x.CreatedAt,
                        ProductName = x.Product.ProductName // Assuming you have a navigation property for Product
                    })
                    .ToList();
            }
        }

        public List<ReviewDTO> getApprovedReviewsFromDatabase()
        {
            using (var db = new ReviewContext())
            {
                return db.Reviews
                    .Where(x => x.Approved)
                    .Select(x => new ReviewDTO
                    {
                        ReviewId = x.ReviewId,
                        ProductId = x.ProductId,
                        UserName = x.UserName,
                        Rating = x.Rating,
                        Text = x.Text,
                        Approved = x.Approved,
                        CreatedAt = x.CreatedAt,
                        ProductName = x.Product.ProductName // Assuming you have a navigation property for Product
                    })
                    .ToList();
            }
        }

        public List<ReviewDTO> getAllReviewsFromDatabase()
        {
            using (var db = new ReviewContext())
            {
                return db.Reviews
                    .Select(x => new ReviewDTO
                    {
                        ReviewId = x.ReviewId,
                        ProductId = x.ProductId,
                        Approved = x.Approved,
                        //UserId = x.UserId,
                        Rating = x.Rating,
                        Text = x.Text
                    })
                    .ToList();
            }
        }

        public void AcceptReview(int reviewId)
        {
            using (var context = new ReviewContext())
            {
                var reviewDb = context.Reviews.FirstOrDefault(p => p.ReviewId == reviewId);
                if (reviewDb != null)
                {
                    reviewDb.Approved = true;
                    context.SaveChanges();
                }
            }
        }



        public void DenyReview(int reviewId)
        {
            using (var context = new ReviewContext())
            {
                var reviewDb = context.Reviews.FirstOrDefault(p => p.ReviewId == reviewId);
                if (reviewDb != null)
                {
                    context.Reviews.Remove(reviewDb);
                    context.SaveChanges();
                }
            }
        }

        public void deleteReview(int id)
        {
            using (var context = new ReviewContext())
            {
                var reviewDb = context.Reviews.FirstOrDefault(p => p.ReviewId == id);
                if (reviewDb != null)
                {
                    context.Reviews.Remove(reviewDb);
                    context.SaveChanges();
                }
            }
        }
        public bool checkIfReviewIdExists(int id)
        {
            using (var db = new ReviewContext())
            {
                return db.Reviews.Any(x => x.ReviewId == id);
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
    
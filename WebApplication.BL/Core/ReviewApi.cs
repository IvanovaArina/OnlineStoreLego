using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.BL.DBModel;

namespace WebApplication.BL.Core
{
    public class ReviewApi
    {
        public ReviewDTO getReviewDTObyNumber(int number)
        {
            ReviewDTO local = null;
            using (var db = new ReviewContext())
            {
                var dbProduct = db.Reviews.FirstOrDefault(x => x.ReviewNumber == number);
                if (dbProduct != null)
                {
                    local = new ReviewDTO
                    {
                        ReviewId = dbProduct.ReviewId,
                        ProductID = dbProduct.ProductID,
                        Approved  = dbProduct.Approved,
                        ReviewNumber = dbProduct.ReviewNumber,
                        UserID = dbProduct.UserID,
                        Rating = dbProduct.Rating,
                        Text = dbProduct.Text,
                     
                    };
                }
            }

            return local;
        }

        public List<ReviewDTO> getReviewsFromDatabase(int reviewCount)
        {
            List<ReviewDTO> listOfReviewDTO = new List<ReviewDTO>();

            for (int i = 0; i < reviewCount; i++)
            {
                ReviewDTO reviewDTO = getReviewDTObyNumber(i);

                    listOfReviewDTO.Add(getReviewDTObyNumber(i));
                
            }

            return listOfReviewDTO;
        }


    }
}

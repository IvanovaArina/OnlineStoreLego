using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;

namespace WebApplication.Models
{
    public class ReviewModel
    {
        public ReviewApi productApi;
        public int countReviews;

        public int ReviewId { get; set; }

        public int ProductID { get; set; }

        public bool Approved { get; set; }
        public int ReviewNumber { get; set; }

        public int UserID { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }

        public ReviewModel()
        {
            productApi = new ReviewApi();
            countReviews = 100;
        }

        public List<ReviewDTO> dataForTable(int count)
        {
            return productApi.getReviewsFromDatabase(count);
        }
    }
}
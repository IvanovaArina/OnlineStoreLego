using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Core;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;

namespace WebApplication.Models
{
    public class ReviewModel
    {
        public ReviewApi reviewApi;


        public int ReviewId { get; set; }

        public ProductTable Product { get; set; }

        public bool Approved { get; set; }
        public UDbTable User { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }

        public ReviewModel()
        {
            reviewApi = new ReviewApi();

        }

        public List<ReviewDTO> approvedReviewForTable()
        {
            return reviewApi.getApprovedReviewsFromDatabase();
        }

        public List<ReviewDTO> pendingReviewForTable()
        {
            return reviewApi.getPendingReviewsFromDatabase();
        }

        public List<ReviewDTO> reviewForTable()
        {
            return reviewApi.getAllReviewsFromDatabase();
        }
    }
}
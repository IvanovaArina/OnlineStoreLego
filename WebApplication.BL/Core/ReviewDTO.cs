using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.BL.Core
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }

        public int ProductID { get; set; }

        public bool Approved { get; set; }
        public int ReviewNumber {  get; set; }

        public int UserID { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }
    }
}

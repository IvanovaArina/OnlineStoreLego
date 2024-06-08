using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Admin;

namespace WebApplication.Domain.Entities.User
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductTable Product { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }
        //public virtual UDbTable User { get; set; }

        public string UserName { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Text { get; set; }

        public bool Approved { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}

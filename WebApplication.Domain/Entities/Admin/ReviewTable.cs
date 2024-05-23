using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities.Admin
{
    public class ReviewTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Required]
        public bool Approved { get; set; }

        [Required]
        public int ReviewNumber { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Range(0, 5)]
        [Required]
        public int Rating { get; set; }

        [Required]
        public string Text { get; set; }


    }

}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Admin;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL.Core
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public bool Approved { get; set; }
        //public UserDTO User { get; set; }  
        public string UserName { get; set; } // Добавляем поле для имени пользователя
        public DateTime CreatedAt { get; set; }
        public string ProductName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities.User
{
    public class ULoginData
    {
        public string UserName { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }
        public string UserIp { get; set; }
        //public string LogibIp { get; set; }
        //public DateTime LoginDateTime { get; set; }
        //public URole Level { get; set; }
    }
}

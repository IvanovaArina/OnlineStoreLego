﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreLego.Web.Data.Models;

namespace OnlineStoreLego.Web.Data.Interfaces
{
    public interface ILegosCategory
    {
        IEnumerable<Category> AllCategories { get;}
    }
}

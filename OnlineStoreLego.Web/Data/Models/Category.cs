using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStoreLego.Web.Data.Models
{
    public class Category{

        public int id { get; set; }

        public string categoryName { get; set; }

        public string categoryDescription { get; set; }

        public List<LegoItem> items { get; set; }

        public Category(string categoryName, string categoryDescription)
        {
            this.categoryName = categoryName;
            this.categoryDescription = categoryDescription;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStoreLego.Web.Data.Models
{
    public class LegoItem{
        public int id { get; set; }
        public string name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string img { get; set; } // url adress
        public decimal price { get; set; }
        public bool isFavorite { get; set; }
        public int available {  get; set; }
        public int categoryId { get; set; }
        public virtual Category Category { get; set; }

        public LegoItem(string name, string ShortDescription, string LongDescription, string img, decimal price, bool isFavorite, int available, Category Category)
        {
            this.name = name;   
            this.ShortDescription = ShortDescription;
            this.LongDescription = LongDescription;
            this.img = img;
            this.price = price;
            this.isFavorite = isFavorite;
            this.available = available;
            this.Category = Category;
        }

    }
}
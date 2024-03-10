using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStoreLego.Web.Data.Interfaces;
using OnlineStoreLego.Web.Data.Models;

namespace OnlineStoreLego.Web.Data.Mocks
{

    //Mocks - классы, которые реализуют интерфейсы, наполняют информацией модели 
    public class MockCategory : ILegosCategory {
        public IEnumerable<Category> AllCategories
        {
           get {
                 return new List<Category>{
                       new Category ("Lego City", "Lego City Description"),
                       new Category ("Lego Star Wars", "Lego Star Wars Description")
              };
           }
        }

        //add category
     }
}
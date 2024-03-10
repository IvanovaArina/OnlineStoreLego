using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using OnlineStoreLego.Web.Data.Interfaces;
using OnlineStoreLego.Web.Data.Models;

namespace OnlineStoreLego.Web.Data.Mocks
{
    public class MockAllItems : IAllItems
    {
        private readonly ILegosCategory _categoryLegos = new MockCategory();
        public IEnumerable<LegoItem> Items {
            get {
                return new List<LegoItem>{
                    new LegoItem("Lego London", "", "", "", 300, true, 5, _categoryLegos.AllCategories.First())
                }
            };
            set {
            };
        }

        public IEnumerable<LegoItem> favoriteItems { get; set; }

        public LegoItem getLegoItem(int LegoItemId)
        {
            throw new NotImplementedException();
        }

        //add item
    }
}
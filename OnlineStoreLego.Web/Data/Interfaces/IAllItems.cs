using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreLego.Web.Data.Models;

namespace OnlineStoreLego.Web.Data.Interfaces
{
    internal interface IAllItems
    {
        IEnumerable<LegoItem> Items { get; set; }
        IEnumerable<LegoItem> favoriteItems { get; set; }
        LegoItem getLegoItem(int LegoItemId);
    }
}

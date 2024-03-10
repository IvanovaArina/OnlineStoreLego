using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStoreLego.Web.Data.Models;

namespace OnlineStoreLego.Web.ViewModels
{
    //ViewModels - храним большие данные в отдельных моделях, которые исключительно для шаблонов
    public class ItemsListViewModel
    {
        public IEnumerable<LegoItem> allItems { get; set; }
        public string currentCategory { get; set; }

    }
}
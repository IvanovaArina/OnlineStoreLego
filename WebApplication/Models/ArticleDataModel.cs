using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.BL.Models;

namespace WebApplication.Models
{
    public class ArticleDataModel
    {
        public ArticleDataModelWithActions articleDataModelWithActions;

        public ArticleDataModel()
        {
            articleDataModelWithActions = new ArticleDataModelWithActions();
        }

        public List<Tuple<int, string, string, string>> dataForTable()
        {
            return articleDataModelWithActions.dataForTable();
        }


    }
}
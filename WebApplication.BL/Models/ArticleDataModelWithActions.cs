using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WebApplication.BL.Models
{
    public class ArticleDataModelWithActions
    {






        public List<Tuple<int, string, string, string>> dataForTable()
        {
            List<Tuple<int, string, string, string>> tupelsWithArticlesData = new List<Tuple<int, string, string, string>>();


            tupelsWithArticlesData.Add(Tuple.Create(1, "Title1", "Author1", "Category1"));
            tupelsWithArticlesData.Add(Tuple.Create(1, "Title eva", "Author eva", "Category eva"));


            return tupelsWithArticlesData;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities
{
    public class MyIntIds
    {
        public List<int> IntIds { get; set; } = new List<int>();

        public void addToListIds(int id)
        {
            IntIds.Add(id);
        }


    }
}

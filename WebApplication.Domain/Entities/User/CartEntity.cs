using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities.User
{
    public class CartEntity
    {

        public Dictionary<int, int> cartItemsIdsAndCount = new Dictionary <int, int>();

    }
}

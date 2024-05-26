using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entities.User
{
    public class WishlistEntity
    {
        public List <int> productsIds;

        public WishlistEntity() {
            productsIds = new List<int>();
        }

    }
}

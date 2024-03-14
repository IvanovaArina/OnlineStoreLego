using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccess;

namespace BusinessLogic
{
    public class UserBL
    {
        public CustomBO addUser (UserBO objUserBO)
        {
            return new UserDAL().addUser(objUserBO);
        }
    }
}

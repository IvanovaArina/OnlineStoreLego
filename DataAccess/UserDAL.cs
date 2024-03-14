using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
//using BusinessLogic.UserBO;

namespace DataAccess
{
    public class UserDAL
    {
        private UserDBEbtities objUserDbEntities;
        public UserDAL()
        {
            objUserDbEntities = new UserDBEbtities();
        }

        public CustomBO addUser(UserBO objUserBO)
        {
            return new CustomBO();
        }

        /*public CustomBO AddUser(UserBO objUserBO)
        {
            UserDBEbtities 
        }
        */ // with DB




    }
}

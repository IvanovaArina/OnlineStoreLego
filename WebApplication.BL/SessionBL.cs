using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplication.BL.Core;
using WebApplication.BL.Interfaces;
using WebApplication.Domain.Entities.Responces;
using WebApplication.Domain.Entities.User;

namespace WebApplication.BL
{
    public class SessionBL : UserApi, ISession
    {
        public BaseResponces ValidateUserCredentialAction(ULoginData ulData)
        {
            return CheckUserCredential(ulData);


        }

        public BaseResponces RegisterUserActionFlow(USignInData userModel)
        {
            return RegisterNewUserAccaunt(userModel);
        }

        public BaseResponces GenerateUserSessionActionFlow(ULoginData ulData)
        {

            return GenerateUserSession(ulData);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }
    }
}

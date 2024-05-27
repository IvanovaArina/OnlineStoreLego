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
        public BaseResponces ValidateUserCredentialAction(UserDTO userDTO)
        {
            return CheckUserCredential(userDTO);
        }

        public BaseResponces RegisterUserActionFlow(UserDTO userDTO)
        {
            return RegisterNewUserAccount(userDTO);
        }

        public BaseResponces GenerateUserSessionActionFlow(UserDTO userDTO)
        {

            return GenerateUserSession(userDTO);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }
    }
}

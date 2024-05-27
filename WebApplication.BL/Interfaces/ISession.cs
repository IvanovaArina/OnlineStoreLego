using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;
using WebApplication.Domain.Entities.Responces;
using System.Web;
using WebApplication.BL.Core;

namespace WebApplication.BL.Interfaces
{
    public interface ISession
    {
        BaseResponces GenerateUserSessionActionFlow(UserDTO userDTO);
        BaseResponces RegisterUserActionFlow(UserDTO userDTO);
        BaseResponces ValidateUserCredentialAction(UserDTO userDTO);
        HttpCookie GenCookie(string loginCredential);
    }
}

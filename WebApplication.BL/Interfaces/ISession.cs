using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.User;
using WebApplication.Domain.Entities.Responces;
using System.Web;

namespace WebApplication.BL.Interfaces
{
    public interface ISession
    {
        BaseResponces GenerateUserSessionActionFlow(ULoginData ulData);
        BaseResponces RegisterUserActionFlow(USignInData userModel);
        BaseResponces ValidateUserCredentialAction(ULoginData uldata);
        HttpCookie GenCookie(string loginCredential);
    }
}

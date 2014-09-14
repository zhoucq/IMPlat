using Imp.Core.Domain.Users;

namespace Imp.Services.Security
{
    public interface IAuthenticationService
    {
        void SignIn(User user,bool createPersitentCookie);

        void SignOut();

        User GetAuthenticatedUser();
    }
}
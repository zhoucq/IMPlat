using System;
using System.Web;
using System.Web.Security;
using Imp.Core.Domain.Users;
using Imp.Services.Users;

namespace Imp.Services.Security
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public class FormsAuthenticationService : IAuthenticationService
    {

        #region Field
        private IUserService _userService;
        private HttpContext _httpContext;
        #endregion

        #region Ctor
        public FormsAuthenticationService(IUserService userService)
        {
            _userService = userService;
            _httpContext = HttpContext.Current;
        }
        #endregion

        #region Methods

        /// <summary>
        /// SignIn
        /// </summary>
        /// <param name="user"></param>
        /// <param name="createPersitentCookie"></param>
        public void SignIn(User user, bool createPersitentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1,
                user.Name,
                now,
                now.Add(TimeSpan.FromMinutes(30)),
                createPersitentCookie,
                user.Name,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) { HttpOnly = true };

            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            cookie.Path = FormsAuthentication.FormsCookiePath;

            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            // _httpContext.Response.Cookies.Add(cookie);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// SignOut
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// get current logged in user
        /// </summary>
        /// <returns></returns>
        public User GetAuthenticatedUser()
        {
            if (_httpContext == null || !_httpContext.Request.IsAuthenticated ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }
            var formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
            var user = GetAuthenticatedUserFromTicket(formsIdentity.Ticket);
            return user;
        }

        /// <summary>
        /// get logged in user by ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public User GetAuthenticatedUserFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }

            var username = ticket.UserData;
            var user = _userService.GetUserByUsername(username);
            return user;
        }

        #endregion
    }
}
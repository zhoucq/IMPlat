using Imp.Core.Domain.Users;

namespace Imp.Services.Security
{
    public class PermissionService : IPermissionService
    {
        #region Fields
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Ctor
        public PermissionService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        #endregion

        #region Methods
        public bool Authorize(string permissionName, User user)
        {
            throw new System.NotImplementedException();
        }

        public bool Authorize(string permissionName)
        {
            //TODO: 权限认证
            return _authenticationService.GetAuthenticatedUser() != null;
        }
        #endregion
    }
}
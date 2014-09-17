using Imp.Core.Domain.Users;

namespace Imp.Services.Security
{
    public interface IPermissionService
    {
        bool Authorize(string permissionName, User user);
        bool Authorize(string permissionName);
    }
}
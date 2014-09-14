using Imp.Core.Domain.Users;

namespace Imp.Services.Security
{
    public interface IPermissionService
    {
        bool Authroize(string permissionName, User user);
        bool Authroize(string permissionName);
    }
}
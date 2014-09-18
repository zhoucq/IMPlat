using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Users;

namespace Imp.Services.Users
{
    /// <summary>
    /// user service interface
    /// </summary>
    public interface IUserService
    {
        #region Users

        User GetUser(string id);

        void UpdateUser(User user);
        /// <summary>
        /// 根据用户名获取User
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUserByUsername(string username);

        void InsertUser(User user);

        IList<User> GetAllUser();

        #endregion

        #region Roles
        /// <summary>
        /// get all user roles
        /// </summary>
        /// <returns>role collection</returns>
        IList<Role> GetAllRoles();

        /// <summary>
        /// get role by id
        /// </summary>
        /// <returns></returns>
        Role GetRoleById(string id);

        Role GetRoleByName(string name);

        void InsertRole(Role role);

        void UpdateRole(Role role);

        #endregion
    }
}

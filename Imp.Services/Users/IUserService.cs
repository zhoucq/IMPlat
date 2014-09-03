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
        /// <summary>
        /// 根据用户名获取User
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUserByUsername(string username);

        void InsertUser(User user);

        #endregion
    }
}

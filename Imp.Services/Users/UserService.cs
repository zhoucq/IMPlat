using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Data;
using Imp.Core.Domain.Users;

namespace Imp.Services.Users
{
    /// <summary>
    /// User service
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields
        private IRepository<User> _userRepository;
        #endregion

        #region Ctor
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// get user by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            var query = from o in _userRepository.Table
                        where o.Name == username
                        select o;
            var user = query.FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="user">User</param>
        public void InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            _userRepository.Insert(user);
        }

        #endregion
    }
}

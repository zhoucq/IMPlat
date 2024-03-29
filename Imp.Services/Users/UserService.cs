﻿using System;
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
        private IRepository<Role> _roleRepository;
        #endregion

        #region Ctor
        public UserService(IRepository<User> userRepository,
            IRepository<Role> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        #endregion

        #region Methods

        public User GetUser(string id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            _userRepository.Update(user);
        }
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

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public IList<User> GetAllUser()
        {
            return _userRepository.Table.Where(m => m.Deleted == false).ToList();
        }

        #region Roles

        /// <summary>
        /// get all roles
        /// </summary>
        /// <returns></returns>
        public IList<Role> GetAllRoles()
        {
            var roles = from o in _roleRepository.Table where !o.Deleted orderby o.DisplayOrder select o;
            return roles.ToList();
        }

        /// <summary>
        /// get role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRoleById(string id)
        {
            return _roleRepository.GetById(id);
        }

        public Role GetRoleByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            return _roleRepository.Table.First(m => m.Name == name);
        }

        public void InsertRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            _roleRepository.Insert(role);
        }

        public void UpdateRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            _roleRepository.Update(role);
        }

        #endregion

        #endregion
    }
}

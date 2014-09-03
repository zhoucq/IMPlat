using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;

namespace Imp.Core.Domain.Users
{
    /// <summary>
    /// user
    /// </summary>
    public class User : BaseEntity
    {
        private ICollection<Role> _roles;
        private ICollection<UserGroup> _userGroups;

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 账号是否活动
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 账号是否被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// user roles
        /// </summary>
        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        }

        /// <summary>
        /// groups of user
        /// </summary>
        public virtual ICollection<UserGroup> UserGroups
        {
            get { return _userGroups ?? (_userGroups = new List<UserGroup>()); }
            set { _userGroups = value; }
        }
    }
}

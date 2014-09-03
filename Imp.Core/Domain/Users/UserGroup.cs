using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;

namespace Imp.Core.Domain.Users
{
    /// <summary>
    /// 用户组
    /// </summary>
    public class UserGroup : BaseEntity
    {
        private ICollection<User> _users;

        /// <summary>
        /// 用户组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// users belong to the group
        /// </summary>
        public virtual ICollection<User> Users
        {
            get { return _users ?? (new List<User>()); }
            set { _users = value; }
        }
    }
}

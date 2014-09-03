using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;

namespace Imp.Core.Domain.Users
{
    public class Permission : BaseEntity
    {
        private ICollection<Role> _roles;

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限的系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 对应的权限
        /// </summary>
        public ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            protected set { _roles = value; }
        }
    }
}

using System.Collections.Generic;
using IMP.Core;

namespace Imp.Core.Domain.Users
{
    public class Role : BaseEntity
    {
        private ICollection<Permission> _permissions;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色的系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 角色拥有的权限
        /// </summary>
        public virtual ICollection<Permission> Permissions
        {
            get { return _permissions ?? (_permissions = new List<Permission>()); }
            set { _permissions = value; }
        }
    }
}

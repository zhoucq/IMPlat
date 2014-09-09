using System.Collections.Generic;
using IMP.Core;

namespace Imp.Core.Domain.Users
{
    /// <summary>
    /// role
    /// </summary>
    public class Role : BaseEntity
    {
        private ICollection<Permission> _permissions;

        /// <summary>
        /// name of role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// system name of role
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// display order of role
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// system role 
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// permissions of role
        /// </summary>
        public virtual ICollection<Permission> Permissions
        {
            get { return _permissions ?? (_permissions = new List<Permission>()); }
            set { _permissions = value; }
        }
    }
}

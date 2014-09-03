using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;

namespace Imp.Core.Domain.Users
{
    public class User : BaseEntity
    {
        //private ICollection<UserRole> _userRoles;

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
        //public virtual ICollection<UserRole> UserRoles
        //{
        //    get { return _userRoles ?? (_userRoles = new List<UserRole>()); }
        //    protected set { _userRoles = value; }
        //}
    }
}

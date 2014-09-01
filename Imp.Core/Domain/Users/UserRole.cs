using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;

namespace Imp.Core.Domain.Users
{
    public class UserRole : BaseEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
    }
}

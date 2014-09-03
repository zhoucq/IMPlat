using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Users;

namespace Imp.Data.Mapping.Users
{
    /// <summary>
    /// UserGroup map
    /// </summary>
    public class UserGroupMap:BaseEntityMap<UserGroup>
    {
        public UserGroupMap()
        {
            this.ToTable("T_UserGroup");
        }
    }
}

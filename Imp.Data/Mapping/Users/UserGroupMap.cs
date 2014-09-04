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
    public class UserGroupMap : BaseEntityMap<UserGroup>
    {
        public UserGroupMap()
        {
            this.ToTable("T_UserGroup");

            this.HasMany(t => t.Users)
                .WithMany(t => t.UserGroups)
                .Map(m =>
                {
                    m.ToTable("T_User_UserGroup_Mapping");
                    m.MapLeftKey("UserGroupId");
                    m.MapRightKey("UserId");
                });
        }
    }
}

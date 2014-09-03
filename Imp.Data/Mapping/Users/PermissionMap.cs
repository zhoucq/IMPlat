using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Users;

namespace Imp.Data.Mapping.Users
{
    public class PermissionMap : BaseEntityMap<Permission>
    {
        public PermissionMap()
        {
            this.ToTable("T_Permission");
            this.Property(m => m.SystemName).IsRequired();

            //this.HasMany(m => m.Roles)
            //    .WithMany(m => m.Permissions)
            //    .Map(m => m.ToTable("T_Role_Permission_Mapping"));
        }
    }
}

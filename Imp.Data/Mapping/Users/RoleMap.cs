using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Users;

namespace Imp.Data.Mapping.Users
{
    /// <summary>
    /// role map
    /// </summary>
    public class RoleMap : BaseEntityMap<Role>
    {
        public RoleMap()
        {
            this.ToTable("T_Role");
            this.Property(m => m.Name).IsRequired().HasColumnName("Name");
            this.Property(m => m.SystemName).HasColumnName("SystemName");
            this.Property(m => m.DisplayOrder).HasColumnName("DisplayOrder");
            this.HasMany(m => m.Permissions)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("T_Role_Permission_Mapping");
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("PermissionId");
                });

        }
    }
}

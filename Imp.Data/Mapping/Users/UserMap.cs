using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Users;

namespace Imp.Data.Mapping.Users
{
    public class UserMap : BaseEntityMap<User>
    {
        public UserMap()
        {
            this.ToTable("T_User");
            this.Property(u => u.Name).IsRequired().HasColumnName("Name");
            this.Property(u => u.Password).HasColumnName("Password");
            this.Property(u => u.DisplayName).HasColumnName("DisplayName");
            this.Property(u => u.Active).IsRequired().HasColumnName("Active");
            this.Property(u => u.Deleted).IsRequired().HasColumnName("Deleted");
            this.Property(u => u.CreateDate).HasColumnName("CreateDate");

            this.HasMany(u => u.Roles)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("T_User_Role_Mapping");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });

            //this.HasMany(u => u.UserGroups)
            //    .WithMany(t => t.Users)
            //    .Map(m =>
            //    {
            //        m.ToTable("T_User_UserGroup_Mapping");
            //        m.MapLeftKey("UserId");
            //        m.MapRightKey("UserGroupId");
            //    });
        }
    }
}

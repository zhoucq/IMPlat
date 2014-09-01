using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Users;

namespace Imp.Data.Mapping.Users
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("T_User");
            this.HasKey(u=>u.Id);
            this.Property(u => u.Id).HasColumnName("Id");
            this.Property(u => u.Name).IsRequired().HasColumnName("Name");
            this.Property(u => u.Password).HasColumnName("Password");
            this.Property(u => u.DisplayName).HasColumnName("DisplayName");
            this.Property(u => u.Active).HasColumnName("Active");
            this.Property(u => u.Deleted).HasColumnName("Deleted");
            
        }
    }
}

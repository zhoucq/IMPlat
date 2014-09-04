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
            this.HasKey(m => m.Id);
            this.Property(m => m.SystemName).IsRequired();
        }
    }
}

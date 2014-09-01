using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Clients;

namespace Imp.Data.Mapping.Clients
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            this.ToTable("Clients");
            this.HasKey(c => c.Id);
        }
    }
}

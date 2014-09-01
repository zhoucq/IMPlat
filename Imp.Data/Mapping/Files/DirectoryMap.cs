using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Files;

namespace Imp.Data.Mapping.Files
{
    public class DirectoryMap : EntityTypeConfiguration<Directory>
    {
        public DirectoryMap()
        {
            this.ToTable("Directory");
            this.HasKey(dm => dm.Id);
            this.HasOptional(dm => dm.ParentDirectory)
                .WithMany()
                .HasForeignKey(dm => dm.ParentDirectoryId);
        }
    }
}

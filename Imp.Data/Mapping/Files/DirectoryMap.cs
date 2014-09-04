using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Files;

namespace Imp.Data.Mapping.Files
{
    public class DirectoryMap : BaseEntityMap<Directory>
    {
        public DirectoryMap()
        {
            this.ToTable("T_Directory");

            // this.Property(t => t.ParentDirectoryId).HasColumnName("PId");

            this.HasOptional(dm => dm.ParentDirectory)
                .WithMany(dm => dm.SubDirectories)
                .HasForeignKey(dm => dm.ParentDirectoryId);
        }
    }
}

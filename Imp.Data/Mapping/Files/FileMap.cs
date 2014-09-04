using System.Data.Entity.ModelConfiguration;
using Imp.Core.Domain.Files;

namespace Imp.Data.Mapping.Files
{
    public class FileMap : BaseEntityMap<File>
    {
        public FileMap()
        {
            this.ToTable("T_File");

            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.OwnerId).IsRequired().HasColumnName("OwnerId");
            this.Property(t => t.DirectoryId).IsRequired().HasColumnName("DirectoryId");

            this.HasRequired(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId);

            this.HasRequired(t => t.Directory)
                .WithMany(t => t.Files)
                .HasForeignKey(t => t.DirectoryId);
        }

    }
}

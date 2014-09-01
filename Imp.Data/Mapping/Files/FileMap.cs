using System.Data.Entity.ModelConfiguration;
using Imp.Core.Domain.Files;

namespace Imp.Data.Mapping.Files
{
    public class FileMap : EntityTypeConfiguration<File>
    {
        public FileMap()
        {
            this.ToTable("Files");
            this.HasKey(f => f.Id);
        }

    }
}

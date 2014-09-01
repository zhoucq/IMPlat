using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Imp.Data.Models.Mapping
{
    public class DL_FILEMap : EntityTypeConfiguration<DL_FILE>
    {
        public DL_FILEMap()
        {
            // Primary Key
            this.HasKey(t => t.FileId);

            // Properties
            this.Property(t => t.FileId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DL_FILE");
            this.Property(t => t.FileId).HasColumnName("FileId");
        }
    }
}

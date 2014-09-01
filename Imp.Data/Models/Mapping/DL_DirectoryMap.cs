using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Imp.Data.Models.Mapping
{
    public class DL_DirectoryMap : EntityTypeConfiguration<DL_Directory>
    {
        public DL_DirectoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.ParentDirectoryId)
                .HasMaxLength(50);

            this.HasOptional(t => t.ParentDirectoryId).WithMany().HasForeignKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("DL_Directory");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ParentDirectoryId).HasColumnName("ParentDirectoryId");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.LastModifyDate).HasColumnName("LastModifyDate");
        }
    }
}

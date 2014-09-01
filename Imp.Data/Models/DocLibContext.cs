using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Imp.Data.Models.Mapping;

namespace Imp.Data.Models
{
    public partial class DocLibContext : DbContext
    {
        static DocLibContext()
        {
            Database.SetInitializer<DocLibContext>(null);
        }

        public DocLibContext()
            : base("Name=DocLibContext")
        {
        }

        public DbSet<DL_Directory> DL_Directory { get; set; }
        public DbSet<DL_FILE> DL_FILE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DL_DirectoryMap());
            modelBuilder.Configurations.Add(new DL_FILEMap());
        }
    }
}

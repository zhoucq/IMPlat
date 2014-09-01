using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Imp.Data.Mapping.Clients;
using Imp.Data.Mapping.Files;
using Imp.Data.Mapping.Users;

namespace Imp.Data
{
    public class ImpObjectContext : DbContext
    {
        #region Constrator

        public ImpObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(
                m => m.BaseType != null &&
                    m.BaseType.IsGenericType &&
                    m.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>))
                    .Where(m=>m.ToString().Contains("Test"));
            foreach (var type in typesToRegister)
            {
                dynamic instance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(instance);
            }
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

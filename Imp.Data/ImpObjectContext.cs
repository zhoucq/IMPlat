using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Imp.Data
{
    public class ImpObjectContext : DbContext
    {
        #region Constrator

        public ImpObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where (
                m => m.BaseType != null &&
                m.BaseType.IsGenericType &&
                m.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityMap<>) 
            );

            foreach (var type in typesToRegister)
            {
                dynamic instance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(instance);
            }

            // base.OnModelCreating(modelBuilder);
        }
    }
}

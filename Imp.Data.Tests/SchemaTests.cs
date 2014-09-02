using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Imp.Data.Tests
{
    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Can_generate_schema() 
        {
            Database.SetInitializer<ImpObjectContext>(null);
            var ctx = new ImpObjectContext("Test");
            var result = ((IObjectContextAdapter) ctx).ObjectContext.CreateDatabaseScript();
            Assert.NotNull(result);
            Console.WriteLine(result);
        }
    }
}

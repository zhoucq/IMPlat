using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Imp.Data.Tests
{
    [TestFixture]
    public class PersistenceTest
    {
        protected ImpObjectContext context;

        [SetUp]
        public void SetUp()
        {
            // Database.DefaultConnectionFactory
            context = new ImpObjectContext(GetTestDbName());
            context.Database.Delete();
            context.Database.Create();
        }

        private string GetTestDbName()
        {
            // AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ""));
            // const string testDbName = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Movies.mdf;Integrated Security=True;";
            const string testDbName = @"Data Source=(local);Initial Catalog=ImpTests;User Id=sa;Password=P@ssword";
            return testDbName;
        }

        [Test]
        public void Test()
        {
            Assert.IsTrue(true);
        }
    }
}

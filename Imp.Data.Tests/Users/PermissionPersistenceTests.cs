using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Users;
using NUnit.Framework;

namespace Imp.Data.Tests.Users
{
    [TestFixture]
    public class PermissionPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_permission()
        {
            var permission = new Permission
            {
                Name = "P1",
                SystemName = "p1",
                DisplayOrder = 0
            };

            var fromDb = SaveAndLoadEntity(permission);

            Assert.NotNull(fromDb);
            Assert.AreEqual(fromDb.Name, "P1");
        }
    }
}

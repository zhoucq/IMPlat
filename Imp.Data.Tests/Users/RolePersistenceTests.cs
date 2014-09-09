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
    public class RolePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_role()
        {
            var role = new Role
            {
                Name = "测试角色",
                SystemName = "Test Role",
                IsSystemRole = true
            };

            var fromDb = SaveAndLoadEntity(role);
            Assert.NotNull(fromDb);
        }

        [Test]
        public void Can_save_role_with_permissions()
        {
            var role = new Role
            {
                Name = "测试角色",
                SystemName = "Test Role",
                IsSystemRole = false
            };
            role.Permissions.Add(new Permission
            {
                Name = "p1",
                SystemName = "p1"
            });
            role.Permissions.Add(new Permission
            {
                Name = "p2",
                SystemName = "p2"
            });
            var fromDb = SaveAndLoadEntity(role);
            Assert.NotNull(fromDb);
            Assert.AreEqual(fromDb.Name, "测试角色");
            Assert.AreEqual(fromDb.Permissions.Count, 2);
        }
    }
}

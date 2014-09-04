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
    public class UserGroupPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_userGroup_with_users()
        {
            var userGroup = GetUserGroup();

            var fromDb = SaveAndLoadEntity(userGroup);

            Assert.NotNull(fromDb);
            Assert.AreEqual(fromDb.Name, "group 1");
            Assert.AreEqual(userGroup.Users.Count, 2);
        }

        

        private UserGroup GetUserGroup()
        {
            var userGroup = new UserGroup
            {
                Name = "group 1"
            };

            userGroup.Users.Add(new User
            {
                Name = "user1",
                Password = "password1",
                DisplayName = "User1",
                Active = true,
                Deleted = false,
                CreateDate = DateTime.Now
            });

            userGroup.Users.Add(new User
            {
                Name = "user2",
                Password = "password2",
                DisplayName = "User2",
                Active = true,
                Deleted = false,
                CreateDate = DateTime.Now
            });
            return userGroup;
        }
    }
}

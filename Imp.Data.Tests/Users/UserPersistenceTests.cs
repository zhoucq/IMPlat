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
    public class UserPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_user()
        {
            var user = new User
            {
                Name = "User_Test_01",
                Password = "123456",
                DisplayName = "测试用户01",
                Active = true,
                Deleted = false,
                CreateDate = DateTime.Now
            };

            var fromDb = SaveAndLoadEntity(user);
            Assert.NotNull(fromDb);
        }
    }
}

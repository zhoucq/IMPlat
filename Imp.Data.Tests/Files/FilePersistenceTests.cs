using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Files;
using Imp.Core.Domain.Users;
using NUnit.Framework;

namespace Imp.Data.Tests.Files
{
    [TestFixture]
    public class FilePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_file()
        {
            var file = new File
            {
                Name = "file1",
                Owner = GetUser("user2"),
                Directory = GetDirectory(),
                CreateDate = DateTime.Now,
                Deleted = false
            };
            var fromDb = SaveAndLoadEntity(file);
            Assert.NotNull(fromDb);
            Assert.AreEqual(fromDb.Name, "file1");
            Assert.AreEqual(fromDb.Owner.Name, "user2");
            Assert.AreEqual(fromDb.Directory.Name, "dir1");
        }

        private Directory GetDirectory()
        {
            var dir = new Directory
            {
                Name = "dir1",
                IsRoot = true,
                Owner = GetUser("user1"),
                CreateDate = DateTime.Now,
                ParentDirectory = null
            };
            return dir;
        }

        private User GetUser(string name)
        {
            var user = new User
            {
                Name = name,
                Password = "password1",
                Active = true,
                Deleted = false,
                DisplayName = "User 1",
                CreateDate = DateTime.Now
            };
            return user;
        }
    }
}

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
    public class DirectoryPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_directory()
        {
            var dir = new Directory
            {
                Name = "dir1",
                IsRoot = true,
                Owner = GetUser(),
                CreateDate = DateTime.Now,
                ParentDirectory = null
            };

            var fromDb = SaveAndLoadEntity(dir);
            Assert.NotNull(fromDb);
            Assert.AreEqual(fromDb.Owner.Name, "user1");
        }

        [Test]
        public void Can_save_directory_with_parent()
        {
            var user1 = GetUser();
            var dir1 = new Directory
            {
                Name = "dir1",
                IsRoot = true,
                Owner = user1,
                CreateDate = DateTime.Now,
                ParentDirectory = null
            };

            var dir2 = new Directory
            {
                Name = "dir2",
                IsRoot = false,
                Owner = user1,
                CreateDate = DateTime.Now,
                ParentDirectory = dir1
            };

            var fromDb = SaveAndLoadEntity(dir2);
            Assert.NotNull(fromDb);
            Assert.AreEqual(fromDb.ParentDirectory.Name, "dir1");
        }

        [Test]
        public void Can_save_directory_with_subdirectories()
        {
            var user1 = GetUser();
            var dir1 = new Directory
            {
                Name = "dir1",
                IsRoot = true,
                Owner = user1,
                CreateDate = DateTime.Now,
                ParentDirectory = null
            };

            dir1.SubDirectories.Add(
                new Directory
                {
                    Name = "dir2",
                    IsRoot = false,
                    Owner = user1,
                    CreateDate = DateTime.Now,
                    ParentDirectory = dir1
                }
            );

            dir1.SubDirectories.Add(
                new Directory
                {
                    Name = "dir3",
                    IsRoot = false,
                    Owner = user1,
                    CreateDate = DateTime.Now,
                    ParentDirectory = dir1
                }
            );

            var fromDb = SaveAndLoadEntity(dir1);
            Assert.NotNull(fromDb);
            Assert.AreEqual(fromDb.SubDirectories.Count, 2);
        }

        private User GetUser()
        {
            var user = new User
            {
                Name = "user1",
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

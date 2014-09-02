using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;
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
            context = new ImpObjectContext(GetTestDbName());
            // context.Database.Delete();
            // context.Database.Create();
            
            // 初始化数据库： 创建新数据库，根据database\init.sql脚本文件创建表结构
            var objContext = ((IObjectContextAdapter)context).ObjectContext;
            
            DropAndCreateDatabase(objContext, "ImpTests");
            InitialDatabase(objContext);

        }

        protected T SaveAndLoadEntity<T>(T entity) where T : BaseEntity
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            object id = entity.Id;

            context.Dispose();
            context = new ImpObjectContext(GetTestDbName());

            var fromDb = context.Set<T>().Find(id);
            return fromDb;
        }

        #region Database Initialize

        private string GetTestDbName()
        {
            /*
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ""));
            const string testDbName = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\ImpTests.mdf;Integrated Security=True;";
            */
            const string testDbName = @"Data Source=(local);Initial Catalog=ImpTests;User Id=sa;Password=P@ssword";
            return testDbName;
        }

        /// <summary>
        /// 创建测试库
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="dbName"></param>
        private void DropAndCreateDatabase(ObjectContext objContext, string dbName)
        {
            var sql = @"use master
go

if exists(select * from sys.databases where name = '{0}') begin
alter database {0} set  single_user with rollback immediate
go

drop database {0}
go
end 

create database {0}
go

use {0}
go";
            sql = string.Format(sql, dbName);
            sql = sql.Replace("\r\ngo", "");
            objContext.ExecuteStoreCommand(TransactionalBehavior.DoNotEnsureTransaction, sql, null);
        }

        /// <summary>
        /// 执行初始化库脚本
        /// </summary>
        /// <param name="objContext"></param>
        private void InitialDatabase(ObjectContext objContext)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var sqlPath = Path.Combine(new DirectoryInfo(baseDir).Parent.Parent.Parent.FullName, "Database\\init.sql");
            var script = File.ReadAllText(sqlPath);
            script = script.Replace("\r\ngo", "");
            objContext.ExecuteStoreCommand(script);
        }
        #endregion
    }
}

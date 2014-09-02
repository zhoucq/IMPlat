using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using IMP.Core;

namespace Imp.Data
{
    /// <summary>
    /// base entity map
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        #region Ctor
        protected BaseEntityMap()
        {
            // 定义主键字段和属性，字段类型为Varchar,由sqlserver的newid()方法自动生成
            this.HasKey(u => u.Id);
            this.Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(u => u.Id).HasColumnName("Id");
        }
        #endregion
    }
}

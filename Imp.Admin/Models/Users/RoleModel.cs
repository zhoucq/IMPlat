using System.ComponentModel;

namespace Imp.Admin.Models.Users
{
    public class RoleModel
    {
        [DisplayName("角色名称")]
        public string Name { get; set; }

        [DisplayName("角色系统名称")]
        public string SystemName { get; set; }

        [DisplayName("显示顺序")]
        public int DisplayOrder { get; set; }

        [DisplayName("是否系统角色")]
        public bool IsSystemRole { get; set; } 
    }
}
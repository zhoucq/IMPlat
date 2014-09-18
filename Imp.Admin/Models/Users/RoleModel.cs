using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Imp.Web.Framework.Mvc;

namespace Imp.Admin.Models.Users
{
    public class RoleModel : BaseImpEntityModel
    {
        [DisplayName("角色名称")]
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }

        [DisplayName("角色系统名称")]
        public string SystemName { get; set; }

        [DisplayName("显示顺序")]
        [Required(ErrorMessage = "请输入顺序"), RegularExpression(@"^[0-9]*$", ErrorMessage = "请输入数字")]
        public int DisplayOrder { get; set; }

        [DisplayName("是否系统角色")]
        public bool IsSystemRole { get; set; }
    }
}
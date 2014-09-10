using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Imp.Core.Domain.Users;

namespace Imp.Admin.Models.Users
{
    public class UserListModel
    {
        [DisplayName("用户名")]
        public string SearchUsername { get; set; }

        [DisplayName("姓名")]
        public string SearchDisplayName { get; set; }

        [DisplayName("角色")]
        public IList<RoleModel> AvailableRoles { get; set; }

        [DisplayName("角色")]
        public string[] SearchRoleIds { get; set; }
    }
}
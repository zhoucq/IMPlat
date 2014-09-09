using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Imp.Web.Framework.Mvc;

namespace Imp.Admin.Models.Users
{
    public class UserModel : BaseImpEntityModel
    {
        public UserModel()
        {
        }

        [DisplayName("用户名")]
        public string Username { get; set; }

        [DisplayName("密码")]
        public string Password { get; set; }

        [DisplayName("姓名")]
        public string DisplayName { get; set; }
    }
}
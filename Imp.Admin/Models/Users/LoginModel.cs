using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Imp.Web.Framework.Mvc;

namespace Imp.Admin.Models.Users
{
    /// <summary>
    /// login model
    /// </summary>
    public class LoginModel : BaseImpModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}
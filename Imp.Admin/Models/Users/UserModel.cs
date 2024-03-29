﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Imp.Web.Framework.Mvc;

namespace Imp.Admin.Models.Users
{
    public class UserModel : BaseImpEntityModel
    {
        private IList<RoleModel> _availableRoles;

        public UserModel()
        {
        }

        [DisplayName("用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        public string Username { get; set; }

        [DisplayName("密码")]
        public string Password { get; set; }

        [DisplayName("重复密码")]
        [Compare("Password", ErrorMessage = "两次输入的密码不匹配")]
        public string Password2 { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名不能为空")]
        public string DisplayName { get; set; }

        [DisplayName("角色")]
        public IList<RoleModel> AvailableRoles
        {
            get { return _availableRoles ?? (_availableRoles = new List<RoleModel>()); }
            set { _availableRoles = value; }
        }

        [DisplayName("状态")]
        public bool Active { get; set; }

        public IList<RoleModel> SelectedRoles { get; set; }
        public PostedRoles PostedRoles { get; set; }
    }

    public class PostedRoles
    {

        public string[] RoleIds { get; set; }
    }
}
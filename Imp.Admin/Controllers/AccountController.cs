using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Imp.Admin.Models.Users;
using Imp.Core.Domain.Users;
using Imp.Services.Security;
using Imp.Services.Users;
using Imp.Web.Framework.Controllers;

namespace Imp.Admin.Controllers
{
    public class AccountController : BaseController
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IPermissionService _permissionService;
        #endregion

        #region Ctor

        public AccountController(IUserService userService, IAuthenticationService authenticationService, IPermissionService permissionService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _permissionService = permissionService;
        }

        #endregion



        #region Methods

        #region Login / Logout

        // get /account/login
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var user = _userService.GetUserByUsername(loginModel.Username);
            if (user != null && user.Active && !user.Deleted && user.Password.Equals(loginModel.Password))
            {
                _authenticationService.SignIn(user, true);
                return RedirectToAction("Index", "Doc");
            }

            ModelState.AddModelError("", "登录失败，用户名或密码错误");
            return View(loginModel);

        }

        #endregion

        #region Users

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // get /account/users
        // 用户列表
        public ActionResult List()
        {
            if (!_permissionService.Authorize("User.List"))
            {
                return AccessDeniedView();
            }
            var model = new UserListModel();
            model.AvailableRoles = _userService.GetAllRoles().Select(m => m.ToModel()).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult ListUser()
        {
            if (!_permissionService.Authorize("User.List"))
            {
                return AccessDeniedView();
            }
            var users = _userService.GetAllUser();

            var data = new
            {
                data = users
            };
            return Json(data);
        }

        /// <summary>
        /// create a user
        /// </summary>/ 
        /// <returns></returns>
        public ActionResult Create()
        {
            if (!_permissionService.Authorize("User.Create"))
            {
                return AccessDeniedView();
            }

            // all roles
            var model = new UserModel();
            model.AvailableRoles = _userService.GetAllRoles().Select(m => m.ToModel()).ToList();
            model.SelectedRoles = new List<RoleModel>();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (!_permissionService.Authorize("User.Create"))
            {
                return AccessDeniedView();
            }
            var findUser = _userService.GetUserByUsername(model.Username);
            if (findUser != null)
            {
                ModelState.AddModelError("Username", "用户名已经存在");
                // return View(model);
            }
            if (model.PostedRoles == null || model.PostedRoles.RoleIds.Length == 0)
            {
                ModelState.AddModelError("PostedRoles.RoleIds", "至少需要选择一个角色");
            }
            if (!ModelState.IsValid)
            {
                model.AvailableRoles = _userService.GetAllRoles().Select(m => m.ToModel()).ToList();
                return View("Create", model);
            }

            var user = new User();
            user.Name = model.Username;
            user.DisplayName = model.DisplayName;
            user.Password = model.Password;
            user.CreateDate = DateTime.Now;
            user.Active = model.Active;
            user.Deleted = false;
            foreach (var roleId in model.PostedRoles.RoleIds)
            {
                user.Roles.Add(_userService.GetRoleById(roleId));
            }
            _userService.InsertUser(user);
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Edit(string id)
        {
            if (!_permissionService.Authorize("User.Create"))
            {
                return AccessDeniedView();
            }

            var user = _userService.GetUser(id);
            if (user == null)
            {
                return RedirectToAction("List");
            }


            var model = new UserModel();
            model.Id = user.Id;
            model.Username = user.Name;
            model.DisplayName = user.DisplayName;
            model.AvailableRoles = _userService.GetAllRoles().Select(m => m.ToModel()).ToList();
            model.SelectedRoles = user.Roles.Select(m => m.ToModel()).ToList();
            model.Active = user.Active;
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (model == null)
            {
                return RedirectToAction("List");
            }

            if (model.PostedRoles == null || model.PostedRoles.RoleIds.Length == 0)
            {
                ModelState.AddModelError("PostedRoles.RoleIds", "至少需要选择一个角色");
            }
            ModelState.Remove("Username");
            if (ModelState.IsValid)
            {
                var user = _userService.GetUser(model.Id);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
                if (!string.IsNullOrWhiteSpace(model.Password))
                {
                    // 密码为空时，不需要修改密码
                    user.Password = model.Password;
                }

                user.DisplayName = model.DisplayName;
                user.Password = model.Password;
                user.Active = model.Active;
                user.Deleted = false;
                user.Roles.Clear();
                foreach (var roleId in model.PostedRoles.RoleIds)
                {
                    user.Roles.Add(_userService.GetRoleById(roleId));
                }
                _userService.UpdateUser(user);
                return RedirectToAction("List");
            }
            model.AvailableRoles = _userService.GetAllRoles().Select(m => m.ToModel()).ToList();
            return View(model);
        }

        public ActionResult Delete(string id)
        {
            if (!_permissionService.Authorize("User.Delete"))
            {
                return AccessDeniedView();
            }

            var user = _userService.GetUser(id);
            if (user != null)
            {
                user.Deleted = true;
                _userService.UpdateUser(user);
            }
            return RedirectToAction("List");
        }

        #endregion

        #endregion
    }
}

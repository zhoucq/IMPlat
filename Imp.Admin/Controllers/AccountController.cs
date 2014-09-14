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

namespace Imp.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }





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
            var model = new UserListModel();
            model.AvailableRoles = _userService.GetAllRoles().Select(m => m.ToModel()).ToList();
            return View(model);
        }

        /// <summary>
        /// create a user
        /// </summary>/ 
        /// <returns></returns>
        public ActionResult Create()
        {
            // all roles
            ViewBag.AllRoles = _userService.GetAllRoles();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            var allRoles = _userService.GetAllRoles();
            var user = new User
            {
                Name = form["username"],
                Password = form["password"],
                DisplayName = form["displayName"],
                CreateDate = DateTime.Now
            };
            if (string.IsNullOrEmpty(form["role"]))
            {
                throw new ArgumentNullException("role");
            }
            var roleIds = form["role"].Split(',');

            foreach (var roleId in roleIds)
            {
                user.Roles.Add(allRoles.FirstOrDefault(m => m.Id == roleId));
            }
            _userService.InsertUser(user);

            bool continueEditing = form.AllKeys.Contains("continueEditing");
            if (continueEditing)
            {
                return View();
            }
            else
            {
                return RedirectToAction("List", "Account");
            }

        }
        #endregion

        #endregion
    }
}

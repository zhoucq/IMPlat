using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Imp.Core.Domain.Users;
using Imp.Services.Users;

namespace Imp.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult Login()
        {
            var user = _userService.GetUserByUsername("User_Test_01");
            //return Content("");
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        #region Methods

        #region Users

        // get /account/users
        // 用户列表
        public ActionResult List()
        {

            return View();
        }

        /// <summary>
        /// create a user
        /// </summary>
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
            var roleIds = form["role"].Split(',');
            foreach (var roleId in roleIds)
            {
                // user.Roles.Add(_userService.GetRoleById(roleId));
                 user.Roles.Add(allRoles.FirstOrDefault(m => m.Id == roleId));
            }
            _userService.InsertUser(user);
            return Content("添加成功");
        }
        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            return View();
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
        public ActionResult Users()
        {
            return View();
        }
        #endregion

        #endregion
    }
}

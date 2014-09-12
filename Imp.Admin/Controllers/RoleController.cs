using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Imp.Services.Users;

namespace Imp.Admin.Controllers
{
    /// <summary>
    /// role controller
    /// </summary>
    public class RoleController : Controller
    {
        private IUserService _userService;

        public RoleController(IUserService userService)
        {
            _userService = userService;
        }

        #region Methods
        //
        // GET: /Role/

        public ActionResult Index()
        {
            return View();
            // return RedirectToAction("List");
        }


        public ActionResult List()
        {
            ViewBag.Roles = _userService.GetAllRoles();
            return View();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Imp.Admin.Models.Users;
using Imp.Core.Domain.Users;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleModel roleModel)
        {
            if(_userService.GetRoleByName(roleModel.Id)!=null)
                ModelState.AddModelError("Name","名称已经存在");
            if (ModelState.IsValid)
            {
                var role = new Role();
                role.Name = roleModel.Name;
                role.SystemName = string.Empty;
                role.IsSystemRole = roleModel.IsSystemRole;
                role.DisplayOrder = roleModel.DisplayOrder;
                role.Deleted = false;
                _userService.InsertRole(role);
                return RedirectToAction("List");
            }
            return View("Create");
        }

        public ActionResult Edit(string id)
        {
            var role = _userService.GetRoleById(id);
            if (role != null)
            {
                var model = new RoleModel()
                {
                    Id = role.Id,
                    Name = role.Name,
                    IsSystemRole = role.IsSystemRole,
                    DisplayOrder = role.DisplayOrder
                };
                return View(model);
            }
            return View("List");
        }

        [HttpPost]
        public ActionResult Edit(RoleModel roleModel)
        {
            if (roleModel == null) return View("List");
            if (ModelState.IsValid)
            {
                var role = _userService.GetRoleById(roleModel.Id);
                if (role == null) return View("List");
                role.Name = roleModel.Name;
                role.IsSystemRole = roleModel.IsSystemRole;
                role.DisplayOrder = roleModel.DisplayOrder;
                _userService.UpdateRole(role);
                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            var role = _userService.GetRoleById(id);
            if (role != null)
            {
                role.Deleted = true;
                _userService.UpdateRole(role);
            }
            return RedirectToAction("List");
        }

        #endregion
    }
}

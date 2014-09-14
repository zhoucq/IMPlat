using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Imp.Admin.Models.Doc;
using Imp.Core.Domain.Files;
using Imp.Services.Files;
using Imp.Services.Security;
using Imp.Web.Framework.Controllers;

namespace Imp.Admin.Controllers
{
    public class DocController : BaseController
    {
        #region Fields
        private readonly IFileService _fileService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IPermissionService _permissionService;
        #endregion

        #region Ctor
        public DocController(IFileService fileService, IAuthenticationService authenticationService, IPermissionService permissionService)
        {
            _fileService = fileService;
            _authenticationService = authenticationService;
            _permissionService = permissionService;
        }
        #endregion

        #region Methods

        public ActionResult Index()
        {
            return RedirectToAction("List", "Doc");
        }

        public ActionResult List()
        {
            if (!_permissionService.Authroize("Doc.List"))
            {
                return AccessDeniedView();
            }
            return View();
        }

        public ActionResult CreateDirectory(string parentDirectoryId)
        {
            if (!_permissionService.Authroize("Doc.CreateDirectory"))
            {
                return AccessDeniedView();
            }

            var directory = _fileService.GetDirectory(parentDirectoryId);

            var model = new CreateDirectoryModel();
            model.ParentDirectoryId = directory.Id;
            model.ParentDirectoryPath = directory.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateDirectory(CreateDirectoryModel model)
        {
            if (!_permissionService.Authroize("Doc.CreateDirectory"))
            {
                return AccessDeniedView();
            }

            var directory = new Directory();
            directory.Name = model.NewDirectoryName;
            directory.ParentDirectoryId = model.ParentDirectoryId;
            directory.CreateDate = DateTime.Now;
            // directory.Owner=
            directory.Owner = _authenticationService.GetAuthenticatedUser();
            _fileService.CreateDirectory(directory);
            return RedirectToAction("List");
        }
        #endregion
    }
}

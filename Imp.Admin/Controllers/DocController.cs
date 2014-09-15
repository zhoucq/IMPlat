using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Imp.Admin.Models.Doc;
using Imp.Services.Files;
using Imp.Services.Security;
using Imp.Web.Framework.Controllers;
using Directory = Imp.Core.Domain.Files.Directory;

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

        public ActionResult List(string id)
        {
            if (!_permissionService.Authroize("Doc.List"))
            {
                return AccessDeniedView();
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                id = Guid.Empty.ToString();
            }
            var directory = _fileService.GetDirectory(id);
            var model = new DirectoryModel();
            if (directory != null)
            {
                model.Name = directory.Name;
                model.LastModifyDate = directory.LastModifyDate;
                model.Id = directory.Id;
                foreach (var subDirectory in directory.SubDirectories)
                {
                    model.SubDirectories.Add(new DirectoryModel.SubDirectory
                    {
                        Id = subDirectory.Id,
                        Name = subDirectory.Name,
                        LastModifyDate = subDirectory.LastModifyDate
                    }
                    );
                }
            }
            else
            {
                model.Id = id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult DirectoryList(string directoryId)
        {
            if (!_permissionService.Authroize("Doc.List"))
            {
                return AccessDeniedView();
            }

            var subDirectories = _fileService.GetSubDirectories(directoryId);
            return Json(subDirectories, JsonRequestBehavior.AllowGet);
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
            directory.LastModifyDate = DateTime.Now;
            directory.Owner = _authenticationService.GetAuthenticatedUser();
            _fileService.CreateDirectory(directory);
            return RedirectToAction("List");
        }

        public ActionResult UploadFile(string parentDirectoryId)
        {
            if (!_permissionService.Authroize("Doc.UploadFile"))
            {
                return AccessDeniedView();
            }

            // var directory = _fileService.GetDirectory(parentDirectoryId);
            var model = new UploadFileModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (!_permissionService.Authroize("Doc.UploadFile"))
            {
                return AccessDeniedView();
            }
            // var fileName = Path.GetFileName(file.FileName);
            return RedirectToAction("Index");
        }

        #endregion
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Imp.Web.Framework.Mvc;

namespace Imp.Admin.Models.Doc
{
    public class UploadFileModel : BaseImpEntityModel
    {
        public string DirectoryId { get; set; }

        [Display(Name = "文件名")]
        public string FileName { get; set; }

        [Display(Name="选择文件")]
        [DataType(DataType.Upload)]
        [Required]
        public HttpPostedFileBase File { get; set; }

    }
}
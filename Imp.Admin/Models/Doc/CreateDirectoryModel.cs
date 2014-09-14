using System.ComponentModel.DataAnnotations;
using Imp.Web.Framework.Mvc;

namespace Imp.Admin.Models.Doc
{
    public class CreateDirectoryModel : BaseImpModel
    {
        [Display(Name = "上级目录ID")]
        public string ParentDirectoryId { get; set; }

        [Display(Name = "上级目录名称")]
        public string ParentDirectoryPath { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "目录名不能为空")]
        [Display(Name = "目录名称")]
        public string NewDirectoryName { get; set; }
    }
}
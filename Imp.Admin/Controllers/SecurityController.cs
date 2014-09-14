using System.Web.Mvc;
using Imp.Web.Framework.Controllers;

namespace Imp.Admin.Controllers
{
    public class SecurityController : BaseController
    {
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
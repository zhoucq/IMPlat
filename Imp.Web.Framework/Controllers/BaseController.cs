using System.Web.Mvc;
using Imp.Core.Domain.Users;

namespace Imp.Web.Framework.Controllers
{
    public class BaseController : Controller
    {
       
        /// <summary>
        /// Access denied view
        /// </summary>
        /// <returns>Access denied view</returns>
        protected ActionResult AccessDeniedView()
        {
            //return new HttpUnauthorizedResult();
            return RedirectToAction("AccessDenied", "Security", new { pageUrl = this.Request.RawUrl });
        }

    }
}
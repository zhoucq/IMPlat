using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Imp.Admin.Controllers
{
    public class DocController : Controller
    {
        //
        // GET: /Doc/

        public ActionResult Index()
        {
            return RedirectToAction("List", "Doc");
        }

        public ActionResult List()
        {
            return View();
        }

    }
}

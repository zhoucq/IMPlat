using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Imp.Admin.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 测试母版页
        /// </summary>
        /// <returns></returns>
        public ActionResult TestLayout()
        {
            return View();
        }
        /// <summary>
        /// 菜单二
        /// </summary>
        /// <returns></returns>
        public ActionResult Tab2()
        {
            return View();
        }
        /// <summary>
        /// 菜单二
        /// </summary>
        /// <returns></returns>
        public ActionResult Tab3()
        {
            return View();
        }

        /// <summary>
        /// 分部菜单一
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ActionResult PartialTitle(string url)
        {
            var a = url;
            return PartialView();
        }

        public ActionResult PartialMenu(string url)
        {
            return PartialView();
        }

    }
}

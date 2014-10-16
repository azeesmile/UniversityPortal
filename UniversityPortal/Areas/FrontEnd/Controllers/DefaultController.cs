using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityPortal.Areas.FrontEnd.Controllers
{
    public class DefaultController : Controller
    {
        // GET: FrontEnd/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}
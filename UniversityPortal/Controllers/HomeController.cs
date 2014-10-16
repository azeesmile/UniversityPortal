using System.Web.Mvc;

namespace UniversityPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FrontEnd()
        {
            return RedirectToAction("Index", "Home", new { area = "FrontEnd" });
        }
    }
}

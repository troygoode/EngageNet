using System.Web.Mvc;

namespace RPX.Web.MVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "RPXLib Demo";
            ViewData["Message"] = "RPXLib Demo";

            return View();
        }
    }
}
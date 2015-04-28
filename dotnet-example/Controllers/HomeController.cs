using System.Web.Mvc;

namespace dotnet_example.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewData["Message"] = "Welcome to clickSign teste";


            return View();
        }

    }
}

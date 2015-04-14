using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClickSign.APIClientTest.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			var click = new Clicksign.Clicksign ();
			ViewData["Message"] = "Welcome to ASP.NET MVC!" + click.Host;


            return View();
        }

    }
}

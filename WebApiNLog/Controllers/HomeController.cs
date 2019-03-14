using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiNLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Test"];
            return View();
        }
    }
}

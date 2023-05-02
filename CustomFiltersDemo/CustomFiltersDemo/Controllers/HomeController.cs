using CustomFiltersDemo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFiltersDemo.Controllers
{
    public class HomeController : Controller
    {
        [CustomExceptionFilter]
         [CustomAuthentication]
         [CustomActionFilter]
        [CustomResultFilter]
        public ActionResult Index()
        {
            int d = 0;
            var i = 100 / d;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
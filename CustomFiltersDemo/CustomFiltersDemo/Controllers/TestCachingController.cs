using CustomFiltersDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFiltersDemo.Controllers
{
    public class TestCachingController : Controller
    {
        DataManager db=new DataManager();
        // GET: TestCaching
        public ActionResult GetUsers()
        {
            if (HttpContext.Cache["User"] != null)
            {
                return View(HttpContext.Cache["User"]);
            }
            else
            {
                var data = db.Users.ToList();
                HttpContext.Cache.Insert("User", data, null, DateTime.Now.AddMinutes(2), TimeSpan.Zero);
                return View(data);
            }
        }
    }
}
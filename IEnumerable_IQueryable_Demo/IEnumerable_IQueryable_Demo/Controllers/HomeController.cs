using IEnumerable_IQueryable_Demo.DAL;
using IEnumerable_IQueryable_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IEnumerable_IQueryable_Demo.Controllers
{
    public class HomeController : Controller
    {
        DataManager mgr=new DataManager();
        // GET: Home
        public ActionResult Index()
        {
            //  var data = mgr.Students.Where(s => s.FirstName.Equals("Abhijit")).ToString();
            IQueryable<Student> dataa = mgr.Students.Where(d=>d.Standard.Equals(11));
           
            IEnumerable<Student> s=mgr.Students;
            IEnumerable<Student> data=s.Where(a=>a.Standard==11).ToList<Student>();

            //   ViewData["data"] = data;
            ViewBag.Data = data;
            return View();
        }
    }
}
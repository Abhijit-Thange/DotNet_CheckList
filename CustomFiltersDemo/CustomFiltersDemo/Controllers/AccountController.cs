using CustomFiltersDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CustomFiltersDemo.Controllers
{
    public class AccountController : Controller
    {
        DataManager db = new DataManager();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var users=db.Users.FirstOrDefault(x=>x.UserName==user.UserName && x.Password==user.Password);
            if (users != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName,false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
           return RedirectToAction("Index", "Home");
        }
    }
}
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        DataManager db=new DataManager();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
             bool isValid = db.Users.Any(u=>u.UserName == user.UserName && u.Password==user.Password);
            if(isValid)
            {
                // Session["user"]=user;
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index","Home");
            }
            ViewBag.ErrorMessage = "UserName Or Password is wrong";
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if(ModelState.IsValid) 
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
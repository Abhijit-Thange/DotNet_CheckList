using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Login(User user)
        {
             var isValid =await db.Users.FirstOrDefaultAsync(u=>u.UserName == user.UserName && u.Password==user.Password);
            if(isValid != null )
            {

                // Session["user"]=user;
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index","Home");
            }
            ViewBag.ErrorMessage = "UserName Or Password is wrong";
          //  ModelState.AddModelError("", "UserName Or Password is wrong");
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(User user)
        {
            if(ModelState.IsValid) 
            {
                db.Users.Add(user);
               await db.SaveChangesAsync();
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
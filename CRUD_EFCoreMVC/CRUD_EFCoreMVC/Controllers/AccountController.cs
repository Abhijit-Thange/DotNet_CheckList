using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace CRUD_EFCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            var u = await _accountService.SignUp(user);
            if(u)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public async Task<IActionResult> Login(User user)
        {
            var u= await _accountService.Login(user);
            if (u)
            {

            }
            return View();  

        }
    }
}

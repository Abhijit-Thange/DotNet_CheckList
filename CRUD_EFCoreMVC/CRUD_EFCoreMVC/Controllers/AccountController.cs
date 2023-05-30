using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD_EFCoreMVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

       /* public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }*/
      
        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            if(ModelState.IsValid)
            {
                var u = await _accountService.SignUp(user);
                if (u)
                {
                    return RedirectToAction("Login");
                }
            }         
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var u = await _accountService.Login(user);
            if (u)
            {
                 var token = GenerateToken(user);
                //  return Ok(token);
                if(token != null)
                {
                   // Response.Headers.Add("Authorization", "Bearer " + token);
                    Response.Cookies.Append("JwtToken", token);

                    return RedirectToAction("Index", "Category");
                }
                  
            }
            ViewBag.ErrorMessage = "Invalid Username or Password";
            return View();

        }
        
        public string GenerateToken(User user)
        {
            var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            var claims = new Claim[]
            {
                new Claim(type: ClaimTypes.Name, value: user.UserName),
                new Claim(type: ClaimTypes.Role, value: user.UserRole)
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:ValidIssuer"],
                _configuration["Jwt:ValidAudiance"],
                claims,
               expires: DateTime.Now.AddMinutes(10),
               signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            Response.Cookies.Delete("JwtToken");

            return RedirectToAction("Login");
        }
    }
}

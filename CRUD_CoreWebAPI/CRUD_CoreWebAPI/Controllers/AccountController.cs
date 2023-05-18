using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;   
        }

        [HttpPost("signup")]
        public async Task<string> SignUp([FromBody] User users)
        {         
                 var user= await _accountService.SignUp(users);
            if (user)
                return "Regiter Successefully";
            return "Registration faild..";
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var token=await _accountService.Login(user);
            if (string.IsNullOrEmpty(token)) 
                return Unauthorized();

            return Ok(token);
        }
    }
}

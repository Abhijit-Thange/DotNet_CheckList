using CRUD_CoreWebAPI.Database;
using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CRUD_CoreWebAPI.Repository.Repo
{
    public class AccountRepo:IAccountRepo
    {
        private readonly DataManager _dataManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        public AccountRepo(DataManager dataManager, SignInManager<User> signInManager,IConfiguration configuration)
        {
            _dataManager = dataManager;
            _signInManager = signInManager;
            _config = configuration;
        }
        public async Task<bool> SignUp(User user)
        {
            _dataManager.Users.Add(user);
            await _dataManager.SaveChangesAsync();
            return true;
        }

        public async Task<string> Login(User user)
        {
            // var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
            var result=await _dataManager.users.FirstOrDefaultAsync(u=>u.UserName==user.UserName && u.Password==user.Password);
            if (result==null)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role,user.UserRole),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Secret"]));

            var token = new JwtSecurityToken(

                issuer: _config["Jwt:ValidIssuer"],
                audience: _config["Jwt:ValidAudiance"],
                expires:DateTime.Now.AddMinutes(30),
                claims:authClaims,
                signingCredentials:new SigningCredentials(authSigninKey,SecurityAlgorithms.HmacSha256Signature)

                );
          var Token =  new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }

    }
}

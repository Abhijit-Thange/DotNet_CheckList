using CRUD_Operations_Product_and_Category.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace CRUD_Operations_Product_and_Category.JWT_Authentication
{
    public class TokenManager
    {
        private static string Secrat="hsjkdlmjfdiogurkfnrui6783rht";

        public static string GenerateToken(User user)
        {
            byte[] key = Convert.FromBase64String(Secrat);
            SymmetricSecurityKey securityKey=new SymmetricSecurityKey(key);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[] { new Claim(type: ClaimTypes.Name, value: user.UserName, user.UserRole)}),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256),
                Issuer = "https://localhost:44345/",
                Audience= "https://localhost:44345/"
            };
          
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            JwtSecurityTokenHandler tokenHandler=new JwtSecurityTokenHandler();
            if (token == null)
            {
                return null;
            }
          //  JwtSecurityToken jwtToken= (JwtSecurityToken)tokenHandler.ReadToken(token);
           

            byte[] key=Convert.FromBase64String(Secrat);
            TokenValidationParameters paremeters = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime=true
            };

            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, paremeters,out SecurityToken securityToken);
            return principal;
        }

        public static string ValidateToken(string token)
        {
            var userName = "";
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null) { return null; }

            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException) { return null; }
            var user = identity.FindFirst(type:ClaimTypes.Name); //NameIdentifier
            userName = user.Value;
            return userName;
        }
    }
}
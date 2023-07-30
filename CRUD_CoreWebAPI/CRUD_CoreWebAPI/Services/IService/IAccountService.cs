using CRUD_CoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Services.IService
{
    public interface IAccountService
    {
        public Task<bool> SignUp(User user);
        public Task<string> Login(User user);
    }
}

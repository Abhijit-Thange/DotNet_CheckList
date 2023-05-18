using CRUD_CoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Repository.IRepo
{
    public interface IAccountRepo
    {
        public Task<bool> SignUp(User user);
        public Task<string> Login(User user);
    }
}

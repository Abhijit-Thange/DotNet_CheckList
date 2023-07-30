using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;

        public AccountService(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public async Task<bool> SignUp(User user)
        {
            return await _accountRepo.SignUp(user);
        }
        public async Task<string> Login(User user)
        {
            return await _accountRepo.Login(user);
        }
    }
}

using BusinessLogicLayer.IRepo;
using DataAccessLayer.Models;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepo _accountRepo;

        public AccountService(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<bool> Login(User user)
        {
            return await _accountRepo.Login(user);
        }

        public async Task<bool> SignUp(User user)
        {
            return await _accountRepo.SignUp(user);
        }
    }
}

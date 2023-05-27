using BusinessLogicLayer.IRepo;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repo
{
    public class AccountRepo : IAccountRepo
    {
        private readonly DataManager _dataManager;

        public AccountRepo(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<bool> SignUp(User user)
        {
            if(user != null)
            {
                _dataManager.users.Add(user);
                await _dataManager.SaveChangesAsync();
                return true;
            }
           return false;
        }

        public async Task<bool> Login(User user)
        {
            var data=await _dataManager.users.FirstOrDefault(u=>u.UserName == user.UserName && u.Password==user.Password);
            if(data != null)
                return true;

            return false;
        }

        
    }
}

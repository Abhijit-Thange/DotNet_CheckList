using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IRepo
{
    public interface IAccountRepo
    {
        Task<bool> SignUp(User user);
        Task<bool> Login(User user);
    }
}

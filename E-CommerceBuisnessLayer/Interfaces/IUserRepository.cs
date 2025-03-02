using E_CommerceBuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> IsUserNameExist(string UserName);
        Task<bool> IsEmailExist(string Email);
        Task<bool> IsEmailPasswordExist(string Email,string Password);
        Task<User> GetUserByEmail(string Email);


    }
}

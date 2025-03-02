using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.Sevices.UserSevice
{
    public interface IUserService
    {
 
        Task<User> addNewUser(CreateUserDto user);
        Task< bool> IsUserNameExist(string UserName);
        Task< bool> IsEmailExist(string UserName);
        Task<bool> LoginUsingEmailPasswordExist(string email, string password);
        Task<UserDto> GetUserByEmail(string Email);    
    }
} 

using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;


namespace E_CommerceBuisnessLayer.Interfaces.user
{
    public interface IUserService
    {

        Task<User> addNewUser(CreateUserDto user);
        Task<bool> IsUserNameExist(string UserName);
        Task<bool> IsEmailExist(string UserName);
        Task<bool> LoginUsingEmailPasswordExist(string email, string password);
        Task<UserDto> GetUserByEmail(string Email);
    }
}

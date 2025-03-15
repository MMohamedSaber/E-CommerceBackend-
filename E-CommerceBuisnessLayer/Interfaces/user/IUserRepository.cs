using E_CommerceBuisnessLayer.Models;

namespace E_CommerceBuisnessLayer.Interfaces.user
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> IsUserNameExist(string UserName);
        Task<bool> IsEmailExist(string Email);
        Task<bool> IsEmailPasswordExist(string Email, string Password);
        Task<User> GetUserByEmail(string Email);


    }
}

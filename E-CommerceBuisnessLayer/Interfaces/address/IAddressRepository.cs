using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;


namespace E_CommerceBuisnessLayer.Interfaces.address
{
    public interface IAddressRepository : IBaseRepository<Address>
    {

        Task<bool> IsAddressExist(string AddressTitle, int UserId);
        Task<bool> IsAddressExist(int Id);
        Task<Address> GetById(int Id);

    }
}

using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;

namespace E_CommerceBuisnessLayer.Interfaces.address
{
    public interface IAddressService
    {
        Task<bool> AddNewAddress(CreatAddressDto address);
        Task<bool> DeleteAddress(int Id);
        //Task<Task<Address>> Find(int Id);

    }
}
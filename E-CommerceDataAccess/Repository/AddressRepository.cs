using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces.address;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceDataAccess.Repository
{
    public class AddressRepository : BaseRepository<Address>, 
        IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Address> GetById(int Id)
        {
            var  AddressExists = await _context.Addresses.SingleOrDefaultAsync(a => a.Id==Id );
            return AddressExists;
        }

        public async Task<bool> IsAddressExist(string AddressTitle, int UserId)
        {
            bool AddressExists = await _context.Addresses.AnyAsync
                                        (a => a.AddressTitle == AddressTitle &&
                                         a.UserId == UserId);
            return AddressExists;
        }
        
        public async Task<bool> IsAddressExist(int Id)
        {
            bool AddressExists = await _context.Addresses.AnyAsync(a=>a.Id== Id);
            return AddressExists;
        }

       
    }
}

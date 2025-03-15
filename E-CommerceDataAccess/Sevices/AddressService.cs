using AutoMapper;
using E_CommerceBuisnessLayer;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.address;
using E_CommerceBuisnessLayer.Models;


namespace E_CommerceDataAccess.Sevices
{
    public partial class AddressService : IAddressService
    {
        private readonly IUnitOfWork _work;
        private IMapper _mapper;
        public AddressService(IUnitOfWork Work, IMapper mapper)
        {
            _work = Work;
            _mapper = mapper;
        }

        public async Task<bool> AddNewAddress(CreatAddressDto addressDto)
        {

            if (await _work.AddressRepository.IsAddressExist(addressDto.AddressTitle, addressDto.UserId))
               return false;
            

            var address = _mapper.Map<Address>(addressDto);
            await _work.AddressRepository.AddNew(address);
            return true;
        }

        public async Task<bool> DeleteAddress(int ID)
        {
            if ( !await _work.AddressRepository.IsAddressExist(ID))
                return false;

            await _work.AddressRepository.Delete(ID);
            return true;
        }
       
    }
}
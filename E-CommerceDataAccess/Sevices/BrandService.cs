using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.brand;
using E_CommerceBuisnessLayer.Models;
using System.Linq.Expressions;

namespace E_CommerceDataAccess.Sevices
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _work;
        private IMapper _mapper;

        public BrandService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task <IReadOnlyList<BrandDTO>> GetAllAsync()
        {
            var brands = await _work.BrandRepository.GetAllAsync
                (new Expression<Func<Brand, object>>[]{ c => c.Category});
            return _mapper.Map<IReadOnlyList<BrandDTO>>(brands);
        }

        //public async Task< IEnumerable<BrandDTO>> GetAllBrands()
        //{
        //    var brands = await _brandRepository.GetAllAsync(new Expression<Func<Brand, object>>[]{ c => c.Category});
        //    return _mapper.Map<IEnumerable<BrandDTO>>(brands);
        //}
    }
}

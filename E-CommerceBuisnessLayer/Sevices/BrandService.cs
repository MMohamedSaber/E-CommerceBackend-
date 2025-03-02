using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.Sevices
{
    public class BrandService : IBrandService
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private IMapper _mapper;

        public BrandService(IBaseRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task< IEnumerable<BrandDTO>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAll(new Expression<Func<Brand, object>>[]{ c => c.Category});
            return _mapper.Map<IEnumerable<BrandDTO>>(brands);
        }
    }
}

using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.category;
using E_CommerceBuisnessLayer.Models;
using System.Collections.Generic;


namespace E_CommerceDataAccess.Sevices
{
    public class CategoryService : ICategoryService 
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CategoryDTO>> GetAllAsync()
        {
            var categories =  await _work.CategoryRepository.GetAllAsync();

            var categoryDto=   _mapper.Map<IReadOnlyList<CategoryDTO>>(categories);

            return categoryDto;
        }

    }
}
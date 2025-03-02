using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Models;

public class CategoryService : ICategoryService
{
    private readonly IBaseRepository<Category> _categoriesRepository;
    private readonly IMapper _mapper;

    public CategoryService(IBaseRepository<Category> categoriesRepository, IMapper mapper)
    {
        _categoriesRepository = categoriesRepository;
        _mapper = mapper;
    }

    public IEnumerable<CategoryDTO> GetAllCategories()
    {
        var categories = _categoriesRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

}

using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.products;
using E_CommerceBuisnessLayer.Models;
using System.Linq.Expressions;


namespace E_CommerceDataAccess.Sevices
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _productRepository;
        private IMapper _mapper;

        public ProductService(IBaseRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products =await _productRepository.GetAllAsync(new Expression<Func<Product, object>>[]
                                                  {
                                                   c=>c.Category,
                                                   c=>c.Brand
                                                   });

            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }

       
    }
}

using E_CommerceBuisnessLayer.DTOs;

namespace E_CommerceBuisnessLayer.Interfaces.products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}

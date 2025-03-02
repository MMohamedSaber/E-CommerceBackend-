

using E_CommerceBuisnessLayer.DTOs;

namespace E_CommerceBuisnessLayer.Interfaces
{
    public  interface IProductService
    {
        Task <IEnumerable<ProductDto>> GetAllProducts();
    }
}

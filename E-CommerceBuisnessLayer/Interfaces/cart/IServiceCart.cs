using E_CommerceBuisnessLayer.DTOs;

namespace E_CommerceBuisnessLayer.Interfaces.cart
{
    public interface IServiceCart
    {
        Task<Models.Cart> AddToCart(CartDto cartDto);
    }
}


using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.cart;
using E_CommerceBuisnessLayer.Models;

namespace E_CommerceDataAccess.Sevices
{
    public class CartService : IServiceCart
    {
        private readonly IUnitOfWork _work;
        private IMapper _mapper;

        public CartService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task<Cart> AddToCart(CartDto cartDto)
        {
            var cart =_mapper.Map<Cart>(cartDto);
            await _work.CartRepository.AddNew(cart);
            return   cart;
        }
    }
}

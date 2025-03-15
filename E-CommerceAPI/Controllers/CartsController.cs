using E_CommerceAPI.helper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.cart;
using E_CommerceBuisnessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static E_CommerceAPI.Controllers.AddressesController;

namespace E_CommerceAPI.Controllers
{
    [Route("api/Carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IServiceCart _serviceCart;

        public CartsController(IServiceCart serviceCart)
        {
            _serviceCart = serviceCart;
        }

        [Route("AddToCart")]
        [HttpPost]
        public async Task<ActionResult<Cart>> AddToCart(CartDto cartdto)
        {
            if (cartdto.ProductId == 0)
                return BadRequest(new ApiResponse(400, $"Invalid ProductID{cartdto.ProductId}"));
            
            try
            {
               var cart = await _serviceCart.AddToCart(cartdto);
                return Ok(cart);
             
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, ex.Message));
            }
        }

    }
}

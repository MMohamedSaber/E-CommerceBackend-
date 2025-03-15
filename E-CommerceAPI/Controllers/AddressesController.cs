using E_CommerceAPI.helper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces.address;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class AddressesController : ControllerBase 
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("add-new")]
        
        public async Task<ActionResult> AddNewAddress(CreatAddressDto addressDto)
        {
            if (addressDto.UserId == 0 || string.IsNullOrEmpty(addressDto.AddressTitle))
                return BadRequest(new ApiResponse(400,"Invalid vlues"));

            try
            {
                var result = await _addressService.AddNewAddress(addressDto);
                if (result is false)
                    return BadRequest(new ApiResponse(400));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400));
            }

                return Ok(new ApiResponse(200,"Address Added Successfully"));

        }

        [HttpDelete("delete/{Id}")]
        
        public async Task<IActionResult> DeleteAddress(int Id)
        {
            if (Id == 0)
                return BadRequest(new ApiResponse(400,"Invalid Id"  ));

            try
            {
                if (!await _addressService.DeleteAddress(Id))
                return NotFound(new ApiResponse(400,"Id Not Found"  ));


            }
            catch (Exception ex)
            {
                //return NotFound(new ApiResponse<string>("Deleted Failed", null, false));
                return BadRequest(new ApiResponse(400, ex.Message));
            }


            return Ok(new ApiResponse(200,"Address Deleted Successfully"));
        }
    }
}

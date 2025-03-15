using AutoMapper;
using E_CommerceAPI.helper;
using E_CommerceBuisnessLayer;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.brand;
using E_CommerceBuisnessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace E_CommerceAPI.Controllers
{
    [Route("api/Brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService, IUnitOfWork Work)
        {
            _brandService = brandService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult>GetAllBarnds()
        {

            try
            {
                var Brands = await _brandService.GetAllAsync();
                if (Brands != null)
                {
                    return Ok(Brands);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(500, ex.Message));

            }

            return NotFound(new ApiResponse(404,"Not Found Brands"));

        }
    }
}

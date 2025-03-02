using AutoMapper;
using E_CommerceBuisnessLayer;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
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
        private readonly IBrandService _brandRepository;

        public BrandsController(IBrandService brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet("GetAllBarnds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult >GetAllBarnds()
        {
            var brands = await _brandRepository.GetAllBrands();

            if (brands == null || !brands.Any())
            {
                return NotFound(new { Message = "No brands found." });
            }

            return Ok(brands);
        }
    }
}

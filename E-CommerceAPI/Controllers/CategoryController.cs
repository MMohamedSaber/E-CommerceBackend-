using AutoMapper;
using E_CommerceAPI.helper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.category;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryRepositoy;

        public CategoryController(ICategoryService categoryRepositoy)
        {
            _categoryRepositoy = categoryRepositoy;
        }


        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> get()
        {
            try
            {
                var categories =  await _categoryRepositoy.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400));
            }
        }
    }
}

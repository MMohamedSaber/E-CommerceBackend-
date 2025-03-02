using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Models;
using E_CommerceBuisnessLayer.Sevices;
using E_CommerceDataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categorySevice;

        public CategoryController(ICategoryService categorySevice)
        {
          _categorySevice = categorySevice;
        }
        [HttpGet("GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAllCategories()
        {
          var categories = _categorySevice.GetAllCategories();
            return Ok(categories);
        }
    }
}

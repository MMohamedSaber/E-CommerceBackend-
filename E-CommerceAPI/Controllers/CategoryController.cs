using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceDataAccess.Models;
using E_CommerceDataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseRepository<Categori> _categoriesRepository;

        public CategoryController(IBaseRepository<Categori> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        [HttpGet("GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Categori>> GetAllCategories()
        {
           return Ok(_categoriesRepository.GetAll());
        }
    }
}

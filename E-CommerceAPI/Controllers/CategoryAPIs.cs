//using E_CommerceBuisnessLayer;
//using E_CommerceDataAccess;
//using E_CommerceDataAccess.DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace E_CommerceAPI.Controllers
//{
//    [Route("api/Category")]
//    [ApiController]
//    public class CategoryAPIs : ControllerBase
//    {
//        [HttpGet("GetAllCategories")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public ActionResult<List<CategoryDTO>> GetAllCategories()
//        {
//            var categories= Category.GetALLCategories();

//            if (categories == null)
//            {
//                return NotFound("Not Found Categories");
//            }

//            return Ok(categories);
//        }


//    }
//}

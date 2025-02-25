//using E_CommerceBuisnessLayer;
//using E_CommerceDataAccess.DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace E_CommerceAPI.Controllers
//{
//    [Route("api/Brands")]
//    [ApiController]
//    public class BrandAPIs : ControllerBase
//    {

//        [HttpGet("GetAllBarnds")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public ActionResult<List<BrandDTO>> GetAllBarnds()
//        {
//            var brands = Brand.GetAllBrands();

//            if (brands == null)
//            {
//                return NotFound("Brands Not Found");
//            }
//            return Ok(brands);
//        }
//    }
//}

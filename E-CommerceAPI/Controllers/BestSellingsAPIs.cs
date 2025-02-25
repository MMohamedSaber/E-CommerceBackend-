//using E_CommerceBuisnessLayer;
//using E_CommerceDataAccess.DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace E_CommerceAPI.Controllers
//{
//    [Route("api/BestSellings")]
//    [ApiController]
//    public class BestSellingsAPIs : ControllerBase
//    {
//        [HttpGet("Best Sellings")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public ActionResult<List<BestSellingDTO>> BestSellings()
//        {
//            var bestSellings= BestSelling.GetALLBestSelling();

//            if (bestSellings == null )
//            {
//                return NotFound("There is No Best Sellings at Time ");
//            }
//            return Ok(bestSellings);
//        }
//    }
//}

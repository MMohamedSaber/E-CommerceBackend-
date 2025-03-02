using E_CommerceBuisnessLayer;
using E_CommerceBuisnessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/BestSelling")]
    [ApiController]
    public class BestSellingsController : ControllerBase
    {
        private readonly IBestSellingsService _bestSellingsService;

        public BestSellingsController(IBestSellingsService bestSellingsService)
        {
            _bestSellingsService = bestSellingsService;
        }

        [HttpGet("Best Sellings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> BestSelling()
        {
            var bestSellings =  await _bestSellingsService.GetAllBestSellings();
            if (bestSellings == null || !bestSellings.Any())
            {
                return NotFound(new { Message = "No brands found." });
            }

            return Ok(bestSellings);
        }
    }
}

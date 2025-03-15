using E_CommerceAPI.helper;
using E_CommerceBuisnessLayer;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.review;
using E_CommerceBuisnessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static E_CommerceAPI.Controllers.AddressesController;

namespace E_CommerceAPI.Controllers
{
    [Route("api/Reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {

        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("add-new")]
       
        public async  Task<IActionResult>  AddReview(CreateReviewDto reviewDto)
        {
            try
            {

                var result = await _reviewService.AddNew(reviewDto);
                if (result != null)
                {
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(500,$" {ex.Message}"));
            }

            return BadRequest(new ApiResponse(400,"Saved Failed"));
        }


        [HttpPut]
        [Route("update/{Id}")]
        public async Task<IActionResult> UpdateReview(int Id,  CreateReviewDto createReviewDto)
        {
            if (createReviewDto.UserId == 0 || string.IsNullOrEmpty(createReviewDto.Review) || createReviewDto.ProductId == 0)
            {
                return BadRequest(new ApiResponse(400, $"Invalid Id {Id}"));
            }

            try
            {
                var UpdatedReview = await _reviewService.Update(Id, createReviewDto);
                return Ok(UpdatedReview);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(500, $"{ex.Message}"));
            }

        }




        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteReview(int Id)
        {
            if (Id <= 0)
                return BadRequest($"Not valid {Id}");

            try
            { 
               await _reviewService.Delete(Id);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse (400,$"{ex.Message}"));
            }
        }

    }
}

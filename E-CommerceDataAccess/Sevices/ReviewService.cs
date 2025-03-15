using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.review;
using E_CommerceBuisnessLayer.Models;
using E_CommerceBuisnessLayer;

namespace E_CommerceDataAccess.Sevices
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _work;
        private IMapper _mapper;

        public ReviewService(IUnitOfWork Work, IMapper mapper)
        {
            _work = Work;
            _mapper = mapper;
        }

        public async Task<ReviewDetails> AddNew(CreateReviewDto reviewdto)
        {
            var review = _mapper.Map<Review>(reviewdto);

            var newReview=  await _work.ReviewRepository.AddNew(review);

            var reviewDetails = _mapper.Map<ReviewDetails>(newReview);
            return reviewDetails;

        }

        public async Task Delete(int Id)
        {
            await _work.ReviewRepository.Delete(Id);
        }

       

        public async Task<ReviewDetails> Update(int Id,CreateReviewDto reviewdto)
        {
            var  existingReview = await _work.ReviewRepository.Find(Id);

            if (existingReview == null)
                return null;
            

            existingReview.Id = Id;
            existingReview.Stars = reviewdto.Stars;
            existingReview.review = reviewdto.Review;
            existingReview.UserId = reviewdto.UserId;
            existingReview.ProductId = reviewdto.ProductId;

            var UpdatedReview = await _work.ReviewRepository.Update(existingReview);

            var MappedReview = _mapper.Map<ReviewDetails>(UpdatedReview);
            return MappedReview;
        }

       
    }
}

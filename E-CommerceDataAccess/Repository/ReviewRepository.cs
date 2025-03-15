

using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces.review;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceDataAccess.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {}

        public async Task<Review> AddNew(Review review)
        {


           
                await _context.Reviews.AddAsync(review);
                await _context.SaveChangesAsync();
           
                var Review= await _context.Reviews
                .Include(r=>r.User)
                .FirstOrDefaultAsync(r=>r.Id == review.Id);

            return Review;
        }

        public async Task<Review> Update( Review review)
        {
            try
            {
                _context.Update(review);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return review;

        }


        public async Task <Review>Find(int Id)
        {
           

                Review review = await _context.Reviews.FindAsync(Id);
                return review;
           

        }

        
    }
}

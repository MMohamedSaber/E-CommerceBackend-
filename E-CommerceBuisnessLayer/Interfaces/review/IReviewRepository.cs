using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;


namespace E_CommerceBuisnessLayer.Interfaces.review
{
    public interface IReviewRepository : IBaseRepository<Review>
    {

        Task<Review> AddNew(Review review);
        Task<Review> Find(int review);
        Task<Review> Update(Review review);

    }
}

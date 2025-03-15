using E_CommerceBuisnessLayer.Interfaces.topsellings;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;

namespace E_CommerceDataAccess.Repository
{
    public class BestSellingRepository : BaseRepository<BestSelling>, IBestSellingRepository
    {
        public BestSellingRepository(AppDbContext context) : base(context)
        {
        }
    }
}

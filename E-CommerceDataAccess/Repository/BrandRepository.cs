using E_CommerceBuisnessLayer.Interfaces.brand;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;

namespace E_CommerceDataAccess.Repository
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        // for the futur Methods
        public BrandRepository(AppDbContext context) : base(context) {}
    }
}

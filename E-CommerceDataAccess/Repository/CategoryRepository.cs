using E_CommerceBuisnessLayer.Interfaces.category;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;

namespace E_CommerceDataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        // for the futur methods
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}

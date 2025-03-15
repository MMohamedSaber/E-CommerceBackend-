using E_CommerceBuisnessLayer.Interfaces.products;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;
using System.Threading.Tasks;

namespace E_CommerceDataAccess.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        //for the futur methods
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}

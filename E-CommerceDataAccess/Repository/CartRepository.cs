using E_CommerceBuisnessLayer.Interfaces.cart;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;

namespace E_CommerceDataAccess.Repository
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {
        }
        //for the futur methods
    }
}

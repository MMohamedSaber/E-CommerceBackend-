using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.address;
using E_CommerceBuisnessLayer.Interfaces.brand;
using E_CommerceBuisnessLayer.Interfaces.cart;
using E_CommerceBuisnessLayer.Interfaces.category;
using E_CommerceBuisnessLayer.Interfaces.products;
using E_CommerceBuisnessLayer.Interfaces.review;
using E_CommerceBuisnessLayer.Interfaces.topsellings;
using E_CommerceBuisnessLayer.Interfaces.user;
using E_CommerceDataAccess.Data;

namespace E_CommerceDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAddressRepository AddressRepository { get; }

        public IReviewRepository ReviewRepository { get; }

        public ICartRepository CartRepository { get; }

        public IUserRepository UserRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IBestSellingRepository BestSellingRepository { get; }
        public IProductRepository ProductRepository { get; }

        public IBrandRepository BrandRepository  {get ;}

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoryRepository=new CategoryRepository(context);
            AddressRepository=new AddressRepository(context);
            ReviewRepository=new ReviewRepository(context);
            CartRepository=new CartRepository(context);
            BestSellingRepository=new BestSellingRepository(context);
            UserRepository=new UserRepository(context);
            ProductRepository=new ProductRepository(context);
            BrandRepository = new BrandRepository(context);
        }
    }
}

using E_CommerceBuisnessLayer.Interfaces.address;
using E_CommerceBuisnessLayer.Interfaces.brand;
using E_CommerceBuisnessLayer.Interfaces.cart;
using E_CommerceBuisnessLayer.Interfaces.category;
using E_CommerceBuisnessLayer.Interfaces.products;
using E_CommerceBuisnessLayer.Interfaces.review;
using E_CommerceBuisnessLayer.Interfaces.topsellings;
using E_CommerceBuisnessLayer.Interfaces.user;


namespace E_CommerceBuisnessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        public IAddressRepository AddressRepository{ get; }
        public IReviewRepository ReviewRepository { get;  }
        public ICartRepository CartRepository { get; }
        public IUserRepository UserRepository{ get;  }
        public ICategoryRepository CategoryRepository{ get; }
        public IBestSellingRepository BestSellingRepository { get;  }
        public IProductRepository ProductRepository { get;  }
        public IBrandRepository BrandRepository{ get;  }

    }
}

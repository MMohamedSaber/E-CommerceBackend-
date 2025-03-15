using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.topsellings;
using E_CommerceBuisnessLayer.Models;
using System.Linq.Expressions;


namespace E_CommerceDataAccess.Sevices
{
    public class BestSellingService : IBestSellingsService
    {
        private readonly IUnitOfWork _work;
        private IMapper _mapper;

        public BestSellingService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task< IReadOnlyList<BestSellingReadDto>> GetAllBestSellings()
        {
          var bestSellings = await _work.BestSellingRepository
                .GetAllAsync(new Expression<Func<BestSelling,
                               object>>[]{b => b.Product});
            return _mapper.Map<IReadOnlyList<BestSellingReadDto>>(bestSellings);
        }
    }




}

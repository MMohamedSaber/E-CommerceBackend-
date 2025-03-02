using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.Sevices
{
    public class BestSellingService : IBestSellingsService
    {
        private readonly IBaseRepository<BestSelling> _bestSellingRepository;
        private IMapper _mapper;

        public BestSellingService(IBaseRepository<BestSelling> bestSellingRepository, IMapper mapper)
        {
            _bestSellingRepository = bestSellingRepository;
            _mapper = mapper;
        }

        public async Task< IEnumerable<BestSellingReadDto>> GetAllBestSellings()
        {
          var bestSellings = await _bestSellingRepository
          .GetAll(new Expression<Func<BestSelling, object>>[]{b => b.Product});

            return _mapper.Map<IEnumerable<BestSellingReadDto>>(bestSellings);
        }
    }




}

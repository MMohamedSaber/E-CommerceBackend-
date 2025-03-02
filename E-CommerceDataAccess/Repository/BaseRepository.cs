


using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_CommerceDataAccess.Repository
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel: class
    {
       protected  AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context=context;
        }

        public async Task<TModel> AddNew(TModel model)
        {
            await _context.Set<TModel>().AddAsync(model);
            await _context.SaveChangesAsync();
        
            return model;
        }

        public IEnumerable<TModel> GetAll()
        {
            return _context.Set<TModel>()
                .AsNoTracking()
                .ToList();
        }
        

      async Task<IEnumerable<TModel>> IBaseRepository<TModel>.GetAll(Expression<Func<TModel, object>>[] includes)
       {
            IQueryable<TModel> query = _context.Set<TModel>().AsNoTracking();

            foreach (var include in includes)
            {
               query = query.Include(include);
            }
            return query.ToList();
        }
    }
}

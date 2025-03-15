


using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_CommerceDataAccess.Repository
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
       protected  AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context=context;
        }

        public async Task <IReadOnlyList<TModel>> GetAllAsync()
            => await _context.Set<TModel>().AsNoTracking().ToListAsync();
       
        public async Task<IReadOnlyList<TModel>>GetAllAsync(  Expression<Func<TModel, object>>[] includes)
       {
           var query = _context.Set<TModel>().AsNoTracking();

            foreach (var include in includes)
            {
               query = query.Include(include);

            }
            return  await query.ToListAsync();
        }
        public async Task AddNew(TModel model)
        {
           
                await _context.Set<TModel>().AddAsync(model);
                await _context.SaveChangesAsync();
            
          
        }
        public async Task Update(TModel model)
        {
            _context.Entry(model).State=EntityState.Modified;
             await _context.SaveChangesAsync(); 
        }
        public async Task Delete(int  Id)
        {
            var model = await _context.Set<TModel>().FindAsync(Id);
               _context.Set<TModel>().Remove(model);
               _context.SaveChangesAsync();
        }
        public async Task<TModel> GetByIdAsync(int ID)
        {
            var entity = await _context.Set<TModel>().FindAsync(ID);
            return entity;
        }
        public async Task<TModel> GetByIdAsync(int Id, Expression<Func<TModel, object>>[] includes)
        {
            var query = _context.Set<TModel>().AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entity = await query.FirstOrDefaultAsync
                (x => EF.Property<int>(x, "Id") == Id);
            return entity;
        
        }
    }
}

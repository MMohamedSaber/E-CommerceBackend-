using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBuisnessLayer.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        Task <IReadOnlyList<TModel>>GetAllAsync();
        Task <IReadOnlyList<TModel>> GetAllAsync( Expression<Func<TModel, object>>[] includes);
        Task<TModel> GetByIdAsync(int ID);
        Task<TModel> GetByIdAsync(int ID, Expression<Func<TModel, object>>[] includes);
        Task AddNew(TModel model);
        Task Update(TModel model);
        Task Delete(int model);
        
    }
}

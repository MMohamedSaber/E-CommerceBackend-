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
        IEnumerable<TModel> GetAll();
        Task <IEnumerable<TModel>> GetAll( Expression<Func<TModel, object>>[] includes);
        Task<TModel> AddNew(TModel model);
        
    }
}

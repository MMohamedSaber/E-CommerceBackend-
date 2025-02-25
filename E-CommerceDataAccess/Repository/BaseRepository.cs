
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceDataAccess.Data;

namespace E_CommerceDataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
       protected  AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context=context;
        }

        public List<T> GetAll()
        {
            var listOfT = new List<T>();

            listOfT =_context.Set<T>().ToList();

            return listOfT;

        }
    }
}

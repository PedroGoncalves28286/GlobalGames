using System.Linq;
using System.Threading.Tasks;

namespace GlobalGames.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

    }
}

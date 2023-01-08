using Behnam_BehnamAPI.Model;
using System.Linq.Expressions;

namespace Behnam_BehnamAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task Creat(T duty);
        Task Remove(T duty);
        Task Save();
    }
}

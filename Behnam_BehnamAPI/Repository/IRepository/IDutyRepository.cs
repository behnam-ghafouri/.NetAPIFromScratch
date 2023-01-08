using Behnam_BehnamAPI.Model;
using System.Linq.Expressions;

namespace Behnam_BehnamAPI.Repository.IRepository
{
    public interface IDutyRepository:IRepository<Duty>
    {
        Task<Duty> Update(Duty entity);

    }
}

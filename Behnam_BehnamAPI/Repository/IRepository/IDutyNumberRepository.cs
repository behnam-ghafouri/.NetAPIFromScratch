using Behnam_BehnamAPI.Model;
using System.Linq.Expressions;

namespace Behnam_BehnamAPI.Repository.IRepository
{
    public interface IDutyNumberRepository:IRepository<DutyNumber>
    {
        Task<DutyNumber> Update(DutyNumber entity);

    }
}

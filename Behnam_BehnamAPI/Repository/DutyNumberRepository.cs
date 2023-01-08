using Behnam_BehnamAPI.Data;
using Behnam_BehnamAPI.Model;
using Behnam_BehnamAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Behnam_BehnamAPI.Repository
{
    public class DutyNumberRepository : Repository<DutyNumber>, IDutyNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public DutyNumberRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public async Task<DutyNumber> Update(DutyNumber entity)
        {
            entity.CreatedDate = DateTime.Now;
            _db.DutyNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

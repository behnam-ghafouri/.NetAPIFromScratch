using Behnam_BehnamAPI.Data;
using Behnam_BehnamAPI.Model;
using Behnam_BehnamAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Behnam_BehnamAPI.Repository
{
    public class DutyRepository : Repository<Duty>, IDutyRepository
    {
        private readonly ApplicationDbContext _db;

        public DutyRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public async Task<Duty> Update(Duty entity)
        {
            entity.CreatedDate = DateTime.Now;
            _db.Duties.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

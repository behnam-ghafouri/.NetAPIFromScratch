using Behnam_BehnamAPI.Model;
using Behnam_BehnamAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Behnam_BehnamAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<DutyNumber> DutyNumbers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Duty> temp = new List<Duty>();
            for (int i = 1; i < 6; i++)
                temp.Add(new Duty { Id=i,Name = $"test{i}", Rate = "5", ImageUrl = "https://something", Sqft = 100, CreatedDate = DateTime.Now.AddDays(i) });
            modelBuilder.Entity<Duty>().HasData(temp);
        }
    }
}

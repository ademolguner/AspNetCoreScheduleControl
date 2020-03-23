using Microsoft.EntityFrameworkCore;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.DataAccess.Concrete.EntityFramework.Context
{
    public class ScheduleProjectDbContext : DbContext
    {
        public ScheduleProjectDbContext()
        {
        }

        public ScheduleProjectDbContext(DbContextOptions<ScheduleProjectDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ScheduleProjectDb;Trusted_Connection=true");
        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<CashType> CashType { get; set; }
        public DbSet<Cashbox> Cashbox { get; set; }
        public DbSet<FinancialCash> FinancialCash { get; set; }
    }
}
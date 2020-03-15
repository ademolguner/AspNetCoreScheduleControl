using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.DataAccess.Concrete.EntityFramework.Context
{
    public class ScheduleProjectDbContext:DbContext
    {
        public ScheduleProjectDbContext()
        {
                
        }

        public ScheduleProjectDbContext(DbContextOptions<ScheduleProjectDbContext> options) : base(options)
        {
                
        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=JsonWebToken;Trusted_Connection=true");
        }

        public DbSet<Currency> Currency { get; set; }
        
    }
}

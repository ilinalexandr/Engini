using Company.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Infrastructure.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
           : base(options) { }

        public DbSet<EmployeeEntity> Employees => Set<EmployeeEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(e => e.ManagerId);
        }
    }
}

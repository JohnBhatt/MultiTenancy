using Microsoft.EntityFrameworkCore;
using MultiTenancy.Models;
using MultiTenancy.Services;

namespace MultiTenancy.Data
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentTenantService _tenantService;
        public string CurrentTenantId { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentTenantService currentTenantService): base(options)
        {
            _tenantService = currentTenantService;
            CurrentTenantId = _tenantService.TenantId;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        //Override OnModelCreating method to filter by TenantId column on Load.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(a=>a.TenantId == CurrentTenantId);
            modelBuilder.Entity<Person>().HasQueryFilter(a=>a.TenantId == CurrentTenantId);
        }

        //Overriding SaveChanges to add TenantId column value each time entry in entity is added or modified.
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = CurrentTenantId;
                        break;
                }
            }
            var result = base.SaveChanges();
            return result;
        }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
        //    {
        //        if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
        //        {
        //            entry.Entity.TenantId = CurrentTenantId;
        //        }
        //    }
        //    return base.SaveChanges();
        //}

    }
}

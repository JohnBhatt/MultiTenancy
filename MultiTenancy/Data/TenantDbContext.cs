using Microsoft.EntityFrameworkCore;
using MultiTenancy.Models;

namespace MultiTenancy.Data
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {

        }
        public DbSet<Tenant> Tenants { get; set; }
    }
}

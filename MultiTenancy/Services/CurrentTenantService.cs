using Microsoft.EntityFrameworkCore;
using MultiTenancy.Data;

namespace MultiTenancy.Services
{
    public class CurrentTenantService : ICurrentTenantService
    {
        private readonly TenantDbContext _context;
        public string? TenantId { get; set; }
        public CurrentTenantService(TenantDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SetTenant(string tenant)
        {
            var tenantInfo = await _context.Tenants.Where(x=>x.Id== tenant).FirstOrDefaultAsync();
            if (tenantInfo != null)
            {
                TenantId = tenantInfo.Id;
                return true;
            }
            else
            {
                throw new Exception("Invalid Tenant!");
            }
        }
    }
}

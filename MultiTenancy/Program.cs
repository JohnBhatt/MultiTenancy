using Microsoft.EntityFrameworkCore;
using MultiTenancy.Data;
using MultiTenancy.Middleware;
using MultiTenancy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<TenantDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddScoped<ICurrentTenantService, CurrentTenantService>();

var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<TenantResolver>();

app.MapControllers();

app.Run();

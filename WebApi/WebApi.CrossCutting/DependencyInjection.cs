using WebApi.Application.Interfaces;
using WebApi.Application.Services;
using WebApi.Infrastructure.DBContexts;
using WebApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Domain.Interfaces;

namespace CrossCutting;

public static class DependencyInjection
{
  public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<PgSQLContext>(options => options.UseNpgsql(configuration.GetConnectionString("PgSQL")));
    
    services.AddScoped<IHotelService, HotelService>();
    services.AddScoped<IHotelRepository, HotelRepository>();
    
    return services;
  }
}

using HotelReservation.Application.Interfaces;
using HotelReservation.Application.Services;
using HotelReservation.Domain.Interfaces;
using HotelReservation.Infrastructure.DBContexts;
using HotelReservation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting;

public static class DependecyInjection
{
  public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<PgSQLContext>(options => options.UseNpgsql(configuration.GetConnectionString("PgSQL")));
    
    services.AddScoped<IHotelService, HotelService>();
    services.AddScoped<IHotelRepository, HotelRepository>();
    
    return services;
  }
}

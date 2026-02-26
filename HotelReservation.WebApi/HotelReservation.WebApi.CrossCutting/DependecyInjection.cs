using HotelReservation.WebApi.Application.Interfaces;
using HotelReservation.WebApi.Application.Services;
using HotelReservation.WebApi.Domain.Interfaces;
using HotelReservation.WebApi.Infrastructure.DBContexts;
using HotelReservation.WebApi.Infrastructure.Repositories;
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

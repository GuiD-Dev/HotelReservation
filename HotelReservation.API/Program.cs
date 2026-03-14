using CrossCutting;
using HotelReservation.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var dbcontext = scope.ServiceProvider.GetRequiredService<PgSQLContext>();
  dbcontext.Database.Migrate();
}

app.MapControllers();

app.Run();

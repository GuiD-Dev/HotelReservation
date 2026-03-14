using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.DBContexts;

public class PgSQLContext(DbContextOptions<PgSQLContext> options) : DbContext(options)
{
  public DbSet<Hotel> Hotels { get; set; }
  
  override protected void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(PgSQLContext).Assembly);
  }
}

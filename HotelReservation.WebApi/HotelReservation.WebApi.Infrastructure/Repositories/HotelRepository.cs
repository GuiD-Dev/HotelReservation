using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Interfaces;
using HotelReservation.WebApi.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.WebApi.Infrastructure.Repositories;

public class HotelRepository(PgSQLContext context) : IHotelRepository
{
  public async Task<IEnumerable<Hotel>> GetAllAsync(bool asNoTracking = false)
  {
    var query = context.Hotels.AsQueryable();
    if (asNoTracking) query = query.AsNoTracking();
    return await query.ToListAsync();
  }

  public async Task<Hotel> GetOneByIdAsync(int id, bool asNoTracking = false)
  {
    var query = context.Hotels.AsQueryable();
    if (asNoTracking) query = query.AsNoTracking();
    return await query.FirstOrDefaultAsync(h => h.Id == id);
  }

  public async Task<Hotel> CreateAsync(Hotel hotel)
  {
    context.Hotels.Add(hotel);
    await context.SaveChangesAsync();
    return hotel;
  }

  public async Task<Hotel> UpdateAsync(Hotel hotelToUpdate)
  {
    hotelToUpdate.OnUpdateEntity();
    context.Hotels.Update(hotelToUpdate);
    await context.SaveChangesAsync();
    return hotelToUpdate;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    var hotel = await context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
    if (hotel is null) return false;

    context.Hotels.Remove(hotel);
    await context.SaveChangesAsync();
    return true;
  }
}

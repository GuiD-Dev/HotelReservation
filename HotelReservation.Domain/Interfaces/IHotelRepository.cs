using HotelReservation.Domain.Entities;

namespace HotelReservation.Domain.Interfaces;

public interface IHotelRepository
{
  Task<IEnumerable<Hotel>> GetAllAsync(bool asNoTracking = false);
  Task<Hotel> GetOneByIdAsync(int id, bool asNoTracking = false);
  Task<Hotel> CreateAsync(Hotel hotel);
  Task<Hotel> UpdateAsync(Hotel hotelToUpdate);
  Task<bool> DeleteAsync(int id);
}
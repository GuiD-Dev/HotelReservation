using HotelReservation.Application.DTOs;

namespace HotelReservation.Application.Interfaces;

public interface IHotelService
{
  Task<IEnumerable<HotelResponse>> GetAllHotelsAsync();
  Task<HotelResponse> GetHotelByIdAsync(int id);
  Task<HotelResponse> CreateHotelAsync(HotelCreateRequest request);
  Task<HotelResponse> UpdateHotelAsync(int id, HotelUpdateRequest request);
  Task<bool> DeleteHotelAsync(int id);
}
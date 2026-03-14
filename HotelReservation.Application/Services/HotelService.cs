using HotelReservation.Application.DTOs;
using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Interfaces;
using HotelReservation.Domain.ValueObjects;

namespace HotelReservation.Application.Services;

public class HotelService(IHotelRepository repository) : IHotelService
{
  public async Task<IEnumerable<HotelResponse>> GetAllHotelsAsync()
  {
    var result = await repository.GetAllAsync(asNoTracking: true);
    return result.Select(hotel => (HotelResponse)hotel);
  }

  public async Task<HotelResponse> GetHotelByIdAsync(int id)
  {
    var hotel = await repository.GetOneByIdAsync(id, asNoTracking: true);
    return (HotelResponse)hotel ?? throw new Exception($"Hotel with ID: {id} not found.");
  }

  public async Task<HotelResponse> CreateHotelAsync(HotelCreateRequest request)
  {
    return (HotelResponse)await repository.CreateAsync((Hotel)request);
  }

  public async Task<HotelResponse> UpdateHotelAsync(int id, HotelUpdateRequest request)
  {
    var hotelToUpdate = await repository.GetOneByIdAsync(id);
    if (hotelToUpdate is null) throw new InvalidOperationException($"Hotel with ID: {id} not found.");

    hotelToUpdate.Update((Address)request.Address);
    var updatedHotel = await repository.UpdateAsync(hotelToUpdate);
    return (HotelResponse)updatedHotel;
  }

  public async Task<bool> DeleteHotelAsync(int id)
  {
    var deleted = await repository.DeleteAsync(id);
    if (!deleted) throw new InvalidOperationException($"Hotel with ID: {id} not found.");
    return true;
  }
}

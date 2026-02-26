using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Application.DTOs;

public class HotelResponse
{
  public int Id { get; init; }
  public required AddressDto Address { get; init; }
  public bool Active { get; init; }
  public DateTime CreatedAt { get; init; }
  public DateTime UpdatedAt { get; init; }

  public static explicit operator HotelResponse(Hotel hotel) => new HotelResponse
  {
    Id = hotel.Id,
    Address = (AddressDto)hotel.Address,
    Active = hotel.Active,
    CreatedAt = hotel.CreatedAt,
    UpdatedAt = hotel.UpdatedAt,
  };
}

public class HotelCreateRequest
{
  public required AddressDto Address { get; init; }

  public static explicit operator Hotel(HotelCreateRequest request) => new Hotel((Address)request.Address);
}

public class HotelUpdateRequest
{
  public required AddressDto Address { get; init; }
}
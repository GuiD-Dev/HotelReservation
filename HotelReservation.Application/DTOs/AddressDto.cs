using HotelReservation.Domain.ValueObjects;

namespace HotelReservation.Application.DTOs;

public class AddressDto
{
  public int Number { get; init; }
  public required string Street { get; init; }
  public required string City { get; init; }
  public required string State { get; init; }
  public required string Country { get; init; }
  public required string ZipCode { get; init; }

  public static explicit operator AddressDto(Address address) => new AddressDto
  {
    Number = address.Number,
    Street = address.Street,
    City = address.City,
    State = address.State,
    Country = address.Country,
    ZipCode = address.ZipCode
  };

  public static explicit operator Address(AddressDto addressDto) => new Address(
    addressDto.Number,
    addressDto.Street,
    addressDto.City,
    addressDto.State,
    addressDto.Country,
    addressDto.ZipCode
  );
}

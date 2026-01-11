using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Domain.Entities;

public class Hotel : BaseEntity
{
  public Address Address { get; private set; }

  public ICollection<HotelRoom> Rooms { get; private set; } = [];

  public Hotel(Address address)
  {
    DomainException.ThrowsWhen((address == null, "Address cannot be empty."));

    Address = address!;
  }
}

using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Domain.Entities;

public sealed class Hotel : BaseEntity
{
  public Address Address { get; private set; }
  public bool Active { get; private set; } = true;

  private Hotel() { }

  public Hotel(Address address)
  {
    DomainException.ThrowsWhen((address == null, "Address must be provided"));

    Address = address!;
  }

  public void Update(Address address)
  {
    DomainException.ThrowsWhen((address == null, "Address must be provided"));
    
    Address = address!;
  }
}

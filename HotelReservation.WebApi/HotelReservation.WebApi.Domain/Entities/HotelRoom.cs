using HotelReservation.WebApi.Domain.Enums;
using HotelReservation.WebApi.Domain.Exceptions;

namespace HotelReservation.WebApi.Domain.Entities;

public class HotelRoom : BaseEntity
{
  public int Number { get; private set; }
  public HotelRoomKind Kind { get; private set; }
  public DateTime LastCleaning { get; private set; }
  public ICollection<Customer> Customers { get; private set; } = [];

  public HotelRoom(int number, HotelRoomKind kind, DateTime lastCleaning)
  {
    DomainException.ThrowsWhen((number <= 0, "Room number must be greater than zero."));

    Number = number;
    Kind = kind;
    LastCleaning = lastCleaning;
  }
}

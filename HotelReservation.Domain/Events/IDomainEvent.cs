namespace HotelReservation.Domain.Events;

public interface IDomainEvent
{
  DateTime DateOccurred { get; }
}

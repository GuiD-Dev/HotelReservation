namespace HotelReservation.Domain.Events;

public record PaymentApprovedEvent(
  int Id,
  int OrderId,
  decimal Value,
  DateTime PaymentDate,
  string? TransactionCode
) : DomainEventBase;
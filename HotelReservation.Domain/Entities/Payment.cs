using HotelReservation.Domain.Enums;
using HotelReservation.Domain.Exceptions;

namespace HotelReservation.Domain.Entities;

public sealed class Payment : BaseEntity
{
  public decimal Value { get; private set; }
  public PaymentMethod PaymentMethod { get; private set; }

  public Payment(decimal value, PaymentMethod paymentMethod)
  {
    DomainException.ThrowsWhen(
      (value <= 0, "Value must be greater than zero")
    );

    Value = value;
    PaymentMethod = paymentMethod;
  }

}

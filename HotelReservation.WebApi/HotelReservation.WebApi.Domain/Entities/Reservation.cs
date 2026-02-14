using HotelReservation.WebApi.Domain.Exceptions;

namespace HotelReservation.WebApi.Domain.Entities;

public sealed class Reservation : BaseEntity
{
  public int Number { get; private set; }
  public DateTime CheckingDate { get; private set; }
  public DateTime CheckoutDate { get; private set; }
  public bool HasParkingPass { get; private set; }
  public Customer Customer { get; private set; }
  
  public Reservation(int number, DateTime checkingDate, DateTime checkoutDate, bool hasParkingPass, Customer customer)
  {
    DomainException.ThrowsWhen(
      (number <= 0, "Reservation number must be greater than zero"),
      (checkingDate >= checkoutDate, "Checkout date must be later than checking date"),
      (customer == null, "Customer must be informed")
    );

    Number = number;
    CheckingDate = checkingDate;
    CheckoutDate = checkoutDate;
    HasParkingPass = hasParkingPass;
    Customer = customer;
  }
}

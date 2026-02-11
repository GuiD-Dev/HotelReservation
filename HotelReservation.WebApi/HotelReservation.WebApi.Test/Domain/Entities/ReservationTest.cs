using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class ReservationTest : IBaseTest
{
  [Fact]
  public void Should_Create_Entity()
  {
    var number = 1234;
    var checkingDate = DateTime.UtcNow;
    var checkoutDate = DateTime.UtcNow.AddDays(5);
    var hasParkingPass = true;
    var customer = new Customer("John Doe", new IdentifierDocument("999.999.999-99"), "john.doe@example.com", "1234567890");

    var reservation = new Reservation(number, checkingDate, checkoutDate, hasParkingPass, customer);

    Assert.Equal(reservation.Number, number);
    Assert.Equal(reservation.HasParkingPass, hasParkingPass);
    Assert.Equal(reservation.CheckingDate, checkingDate);
    Assert.Equal(reservation.CheckoutDate, checkoutDate);
    Assert.Equal(reservation.Customer, customer);
  }

  public static IEnumerable<object[]> ReservationTestData =>
    new List<object[]>
    {
      new object[] { 0, DateTime.Now, DateTime.Now.AddDays(1) },
      new object[] { 1234, DateTime.Now, DateTime.Now.AddDays(-1) },
    };

  [Theory]
  [MemberData(nameof(ReservationTestData))]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var number = (int)parameters[0];
    var checkingDate = (DateTime)parameters[1];
    var checkoutDate = (DateTime)parameters[2];
    var hasParkingPass = true;
    var customer = new Customer("John Doe", new IdentifierDocument("999.999.999-99"), "john.doe@example.com", "1234567890");

    Assert.Throws<DomainException>(() =>
        new Reservation(number, checkingDate, checkoutDate, hasParkingPass, customer)
    );
  }
}

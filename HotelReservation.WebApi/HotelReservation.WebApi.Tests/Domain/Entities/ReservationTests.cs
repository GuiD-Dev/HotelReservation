using FluentAssertions;
using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class ReservationTests : IBaseTests
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

    reservation.Number.Should().Be(number);
    reservation.HasParkingPass.Should().Be(hasParkingPass);
    reservation.CheckingDate.Should().Be(checkingDate);
    reservation.CheckoutDate.Should().Be(checkoutDate);
    reservation.Customer.Should().Be(customer);
  }

  public static Customer DefaultCustomer = new Customer("John Doe", new IdentifierDocument("999.999.999-99"), "john.doe@example.com", "1234567890");
  public static IEnumerable<object[]> ReservationTestData =>
    new List<object[]>
    {
      new object[] { 0, DateTime.Now, DateTime.Now.AddDays(1), DefaultCustomer,  "Reservation number must be greater than zero" },
      new object[] { 1234, DateTime.Now, DateTime.Now.AddDays(-1), DefaultCustomer, "Checkout date must be later than checking date" },
      new object[] { 1234, DateTime.Now, DateTime.Now.AddDays(1), null, "Customer must be informed" },
    };

  [Theory]
  [MemberData(nameof(ReservationTestData))]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var number = (int)parameters[0];
    var checkingDate = (DateTime)parameters[1];
    var checkoutDate = (DateTime)parameters[2];
    var hasParkingPass = true;
    var customer = parameters[3] as Customer;

    var exception = Assert.Throws<DomainException>(() =>
      new Reservation(number, checkingDate, checkoutDate, hasParkingPass, customer)
    );

    var expectedMessage = (string)parameters[4];
    exception.Message.Should().Be(expectedMessage);
  }
}

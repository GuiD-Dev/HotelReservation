using FluentAssertions;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;
using HotelReservation.Domain.Exceptions;

namespace HotelReservation.Tests.Domain.Entities;

public class PaymentTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var value = 400.00m;
    var method = PaymentMethod.CreditCard;

    var payment = new Payment(value, method);

    payment.Value.Should().Be(value);
    payment.PaymentMethod.Should().Be(method);
  }

  [Theory]
  [InlineData(0.00, "Value must be greater than zero")]
  [InlineData(-1.00, "Value must be greater than zero")]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var value = (decimal)parameters[0];

    var exception = Assert.Throws<DomainException>(() => new Payment(value, PaymentMethod.CreditCard));

    var expectedMessage = (string)parameters[1];
    exception.Message.Should().Be(expectedMessage);
  }
}
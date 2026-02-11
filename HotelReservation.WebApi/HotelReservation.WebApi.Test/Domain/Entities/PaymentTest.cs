using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Enums;
using HotelReservation.WebApi.Domain.Exceptions;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class PaymentTest : IBaseTest
{
  [Fact]
  public void Should_Create_Entity()
  {
    var value = 400.00m;
    var method = PaymentMethod.CreditCard;

    var payment = new Payment(value, method);

    Assert.Equal(payment.Value, value);
    Assert.Equal(payment.PaymentMethod, method);
  }

  [Theory]
  [InlineData(0.00)]
  [InlineData(-1.00)]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var value = (decimal)parameters[0];
    Assert.Throws<DomainException>(() => new Payment(value, PaymentMethod.CreditCard));
  }
}
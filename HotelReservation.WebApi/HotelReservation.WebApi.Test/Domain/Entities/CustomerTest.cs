using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class CustomerTest : BaseTest
{
  [Fact]
  public override void Should_Create_Entity()
  {
    var name = "John Doe";
    var identifierDocument = new IdentifierDocument("999.999.999-99");
    var email = "test@test.com";
    var phone = "11 99999-9999";

    var customer = new Customer(name, identifierDocument, email, phone);

    Assert.Equal(customer.Name, name);
    Assert.Equal(customer.IdentifierDocument, identifierDocument);
    Assert.Equal(customer.Email, email);
    Assert.Equal(customer.Phone, phone);
  }

  [Theory]
  [InlineData("", "999.999.999-99", "test@test.com", "11 99999-9999")]
  [InlineData("John Doe", "", "test@test.com", "11 99999-9999")]
  [InlineData("John Doe", "999.999.999-99", "", "11 99999-9999")]
  [InlineData("John Doe", "999.999.999-99", "test@test.com", "")]
  public override void Should_Throws_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var name = (string)parameters[0];
    var identifierDocument = (string)parameters[1];
    var email = (string)parameters[2];
    var phone = (string)parameters[3];

    Assert.Throws<DomainException>(() => new Customer(name, new IdentifierDocument(identifierDocument), email, phone));
  }
}

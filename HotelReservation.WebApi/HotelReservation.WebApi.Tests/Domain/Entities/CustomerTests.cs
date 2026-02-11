using FluentAssertions;
using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class CustomerTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var name = "John Doe";
    var identifierDocument = new IdentifierDocument("999.999.999-99");
    var email = "test@test.com";
    var phone = "11 99999-9999";

    var customer = new Customer(name, identifierDocument, email, phone);

    customer.Name.Should().Be(name);
    customer.IdentifierDocument.Should().Be(identifierDocument);
    customer.Email.Should().Be(email);
    customer.Phone.Should().Be(phone);
  }

  [Theory]
  [InlineData("", "999.999.999-99", "test@test.com", "11 99999-9999", "Name must not be empty")]
  [InlineData("John Doe", null, "test@test.com", "11 99999-9999", "Identifier Document must not be null")]
  [InlineData("John Doe", "999.999.999-99", "", "11 99999-9999", "Email must not be empty")]
  [InlineData("John Doe", "999.999.999-99", "test@test.com", "", "Phone must not be empty")]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var name = (string)parameters[0];
    var id = (string?)parameters[1];
    var identifierDocument = id != null ? new IdentifierDocument((string)parameters[1]) : null;
    var email = (string)parameters[2];
    var phone = (string)parameters[3];

    var exception = Assert.Throws<DomainException>(() => new Customer(name, identifierDocument, email, phone));

    var expectedMessage = (string)parameters[4];
    exception.Message.Should().Be(expectedMessage);
  }
}

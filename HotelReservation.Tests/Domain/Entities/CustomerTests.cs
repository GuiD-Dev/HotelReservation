using FluentAssertions;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Exceptions;
using HotelReservation.Domain.ValueObjects;

namespace HotelReservation.Tests.Domain.Entities;

public class CustomerTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var name = "John Doe";
    var identifierDocument = new IdentifierDocument("999.999.999-99", DateTime.UtcNow.AddDays(-1));
    var email = "test@test.com";
    var phone = "11 99999-9999";

    var customer = new Customer(name, identifierDocument, email, phone);

    customer.Name.Should().Be(name);
    customer.IdentifierDocument.Should().Be(identifierDocument);
    customer.Email.Should().Be(email);
    customer.Phone.Should().Be(phone);
  }


  public static IEnumerable<object[]> TestData => new List<object[]>
  {
    new object[] { "", new IdentifierDocument("999.999.999-99", DateTime.UtcNow.AddDays(-1)), "test@test.com", "11 99999-9999", "Name must not be empty" },
    new object[] { "John Doe", null, "test@test.com", "11 99999-9999", "Identifier Document must not be null" },
    new object[] { "John Doe", new IdentifierDocument("999.999.999-99", DateTime.UtcNow.AddDays(-1)), "test@test.com", "11 99999-9999", "Identifier Document's format is invalid" },
    new object[] { "John Doe", new IdentifierDocument("000.000.000-00", DateTime.UtcNow.AddDays(-1)), "test@test.com", "11 88888-8888", "Identifier Document's format is invalid" },
    new object[] { "John Doe", new IdentifierDocument("555.555.555-55", DateTime.UtcNow.AddDays(-1)), "", "11 77777-7777", "Email must not be empty" },
    new object[] { "John Doe", new IdentifierDocument("666.666.666-66", DateTime.UtcNow.AddDays(-1)), "", "",   "Email must not be empty and Phone must not be empty" }
  };

  [Theory]
  [MemberData(nameof(TestData))]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var name = (string)parameters[0];
    var id = (string?)parameters[1];
    var identifierDocument = id != null ? new IdentifierDocument((string)parameters[1], DateTime.UtcNow.AddDays(-1)) : null;
    var email = (string)parameters[2];
    var phone = (string)parameters[3];

    var exception = Assert.Throws<DomainException>(() => new Customer(name, identifierDocument, email, phone));

    var expectedMessage = (string)parameters[4];
    exception.Message.Should().Be(expectedMessage);
  }
}

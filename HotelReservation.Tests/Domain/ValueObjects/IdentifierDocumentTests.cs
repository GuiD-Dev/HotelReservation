using FluentAssertions;
using HotelReservation.Domain.Exceptions;
using HotelReservation.Domain.ValueObjects;

namespace HotelReservation.Tests.Domain.ValueObjects;

public class IdentifierDocumentTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var id = "999.999.999-99";
    var shippingDate = DateTime.UtcNow.AddDays(-1);

    var identifierDocument = new IdentifierDocument(id, shippingDate);

    identifierDocument.Id.Should().Be(id);
    identifierDocument.ShippingDate.Should().Be(shippingDate);
  }


  public static IEnumerable<object[]> TestData => new List<object[]>
  {
    new object[] { "", DateTime.UtcNow.AddDays(-1), "Id must not be empty | Id's format specified does not match XXX.XXX.XXX-XX" },
    new object[] { "999.999.999", DateTime.UtcNow.AddDays(-1), "Id's format specified does not match XXX.XXX.XXX-XX" },
    new object[] { "abc999.999.999-99", DateTime.UtcNow.AddDays(-1), "Id's format specified does not match XXX.XXX.XXX-XX" },
    new object[] { "999.999.999-00", DateTime.UtcNow.AddDays(1), "Shipping date cannot be in the future" }
  };

  [Theory]
  [MemberData(nameof(TestData))]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var id = (string)parameters[0];
    var shippingDate = (DateTime)parameters[1];

    var exception = Assert.Throws<DomainException>(() => new IdentifierDocument(id, shippingDate));

    var expectedMessage = (string)parameters[2];
    exception.Message.Should().Be(expectedMessage);
  }
}

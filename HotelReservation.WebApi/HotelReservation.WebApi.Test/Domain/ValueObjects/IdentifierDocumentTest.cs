using FluentAssertions;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.ValueObjects;

public class IdentifierDocumentTest : IBaseTest
{
  [Fact]
  public void Should_Create_Entity()
  {
    var id = "999.999.999-99";

    var identifierDocument = new IdentifierDocument(id);

    identifierDocument.Id.Should().Be(id);
  }


  [Theory]
  [InlineData("", "Id must not be empty | Id's format specified does not match XXX.XXX.XXX-XX")]
  [InlineData("999.999.999", "Id's format specified does not match XXX.XXX.XXX-XX")]
  [InlineData("abc999.999.999-99", "Id's format specified does not match XXX.XXX.XXX-XX")]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var id = (string)parameters[0];
    var exception = Assert.Throws<DomainException>(() => new IdentifierDocument(id));

    var expectedMessage = (string)parameters[1];
    exception.Message.Should().Be(expectedMessage);
  }
}

using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.ValueObjects;

public class IdentifierDocumentTest : BaseTest
{
  [Fact]
  public override void Should_Create_Entity()
  {
    var id = "999.999.999-99";

    var identifierDocument = new IdentifierDocument(id);

    Assert.Equal(id, identifierDocument.Id);
  }


  [Theory]
  [InlineData("")]
  [InlineData("999.999.999")]
  [InlineData("abc999.999.999-99")]
  public override void Should_Throws_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var id = (string)parameters[0];

    Assert.Throws<DomainException>(() => new IdentifierDocument(id));
  }
}

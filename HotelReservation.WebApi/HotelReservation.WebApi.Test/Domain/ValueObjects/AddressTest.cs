using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.ValueObjects;

public class AddressTest : IBaseTest
{
  [Fact]
  public void Should_Create_Entity()
  {
    var validNumber = 123;
    var validStreet = "Main St";
    var validCity = "Springfield";
    var validState = "IL";
    var validZipCode = "62701";

    var address = new Address(validNumber, validStreet, validCity, validState, validZipCode);

    Assert.Equal(address.Number, validNumber);
    Assert.Equal(address.Street, validStreet);
    Assert.Equal(address.City, validCity);
    Assert.Equal(address.State, validState);
    Assert.Equal(address.ZipCode, validZipCode);
  }

  [Theory]
  [InlineData(0, "Main St", "Springfield", "IL", "62701")]
  [InlineData(123, "", "Springfield", "IL", "62701")]
  [InlineData(123, "Main St", "", "IL", "62701")]
  [InlineData(123, "Main St", "Springfield", "", "62701")]
  [InlineData(123, "Main St", "Springfield", "IL", "")]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var number = (int)parameters[0];
    var street = (string)parameters[1];
    var city = (string)parameters[2];
    var state = (string)parameters[3];
    var zipCode = (string)parameters[4];

    Assert.Throws<DomainException>(() => new Address(number, street, city, state, zipCode));
  }
}

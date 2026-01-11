using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class HotelTest : BaseTest
{
  [Fact]
  public override void Should_Create_Entity()
  {
    var address = new Address(123, "Main St", "Springfield", "IL", "62701");

    var hotel = new Hotel(address);

    Assert.Equal(address, hotel.Address);
  }

  public override void Should_Throws_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    throw new NotImplementedException();
  }
}

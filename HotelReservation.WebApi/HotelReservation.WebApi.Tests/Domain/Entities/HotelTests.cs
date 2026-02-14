using FluentAssertions;
using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Tests.Domain.Entities;

public class HotelTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var address = new Address(123, "Main St", "Springfield", "IL", "62701");

    var hotel = new Hotel(address);

    hotel.Address.Should().Be(address);
  }

  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    throw new NotImplementedException();
  }
}

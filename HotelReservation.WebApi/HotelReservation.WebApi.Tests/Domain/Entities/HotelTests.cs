using FluentAssertions;
using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Tests.Domain.Entities;

public class HotelTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var address = new Address(123, "Main St", "Springfield", "IL", "USA", "62701");

    var hotel = new Hotel(address);

    hotel.Address.Should().Be(address);
  }

  [Theory]
  [InlineData(null, "Address must be provided")]
  public void Should_Throw_Exception_When_Invalid_Parameters(params object[] parameters)
  {
    var address = (object?)parameters[0];

    var exception = Assert.Throws<DomainException>(() => new Hotel(address as Address));

    var expectedMessage = (string)parameters[1];
    exception.Message.Should().Be(expectedMessage);
  }
}

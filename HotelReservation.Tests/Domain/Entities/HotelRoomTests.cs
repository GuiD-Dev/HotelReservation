using FluentAssertions;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;
using HotelReservation.Domain.Exceptions;

namespace HotelReservation.Tests.Domain.Entities;

public class HotelRoomTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var number = 101;
    var kind = HotelRoomKind.Single;
    var lastCleaning = DateTime.UtcNow;

    var room = new HotelRoom(number, kind, lastCleaning);

    room.Number.Should().Be(number);
    room.Kind.Should().Be(kind);
    room.LastCleaning.Should().Be(lastCleaning);
  }

  [Theory]
  [InlineData(0, "Room number must be greater than zero")]
  [InlineData(-1, "Room number must be greater than zero")]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var number = (int)parameters[0];
    var kind = HotelRoomKind.Single;
    var lastCleaning = DateTime.UtcNow;

    var exception = Assert.Throws<DomainException>(() => new HotelRoom(number, kind, lastCleaning));

    var expectedMessage = (string)parameters[1];
    exception.Message.Should().Be(expectedMessage);
  }
}
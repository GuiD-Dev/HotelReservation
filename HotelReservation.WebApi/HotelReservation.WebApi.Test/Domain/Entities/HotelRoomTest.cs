using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Enums;
using HotelReservation.WebApi.Domain.Exceptions;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class HotelRoomTest : IBaseTest
{
  [Fact]
  public void Should_Create_Entity()
  {
    var number = 101;
    var kind = HotelRoomKind.Standart;
    var lastCleaning = DateTime.UtcNow;

    var room = new HotelRoom(number, kind, lastCleaning);

    Assert.Equal(room.Number, number);
    Assert.Equal(room.Kind, kind);
    Assert.Equal(room.LastCleaning, lastCleaning);
  }

  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var number = (int)parameters[0];
    var kind = HotelRoomKind.Standart;
    var lastCleaning = DateTime.UtcNow;

    Assert.Throws<DomainException>(() => new HotelRoom(number, kind, lastCleaning));
  }
}
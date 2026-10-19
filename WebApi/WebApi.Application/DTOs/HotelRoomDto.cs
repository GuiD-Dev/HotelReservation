using WebApi.Domain.Entities;
using WebApi.Domain.Enums;

namespace WebApi.Application.DTOs;

public class HotelRoomDto
{
  public int Id { get; private set; }
  public int Number { get; private set; }
  public HotelRoomKind Kind { get; private set; }
  public DateTime LastCleaning { get; private set; }

  public static explicit operator HotelRoomDto(HotelRoom hotelRoom)
  {
    return new HotelRoomDto
    {
      Id = hotelRoom.Id,
      Number = hotelRoom.Number,
      Kind = hotelRoom.Kind,
      LastCleaning = hotelRoom.LastCleaning
    };
  }
}

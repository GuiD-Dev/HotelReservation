namespace HotelReservation.WebApi.Domain.Entities;

public class BaseEntity
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
}

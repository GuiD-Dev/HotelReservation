namespace HotelReservation.WebApi.Domain.Entities;

public class BaseEntity
{
  public int Id { get; private set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

  public void OnUpdateEntity() => UpdatedAt = DateTime.UtcNow;
}

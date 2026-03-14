namespace HotelReservation.Tests.Domain;

public interface IBaseTests
{
  public abstract void Should_Create_Entity();
  public abstract void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters);
}

namespace HotelReservation.WebApi.Test.Domain;

public abstract class BaseTest
{
  public abstract void Should_Create_Entity();
  public abstract void Should_Throws_Exception_When_Invalid_Parameters(params dynamic[] parameters);
}

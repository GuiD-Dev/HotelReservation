namespace HotelReservation.WebApi.Domain.Exceptions;

public class DomainException(string message) : Exception(message)
{
  public static void ThrowsWhen(params (bool, string)[] validations)
  {
    var errors = new List<string>();

    foreach (var validation in validations)
    {
      var result = validation.Item1;
      var message = validation.Item2;

      if (result) errors.Add(message);
    }

    if (errors.Any()) throw new DomainException(string.Join(" | ", errors));
  }
}

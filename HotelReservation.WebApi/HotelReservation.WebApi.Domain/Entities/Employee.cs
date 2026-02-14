using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Domain.Entities;

public sealed class Employee : BaseEntity
{
  public string Name { get; private set; }
  public IdentifierDocument IdentifierDocument { get; private set; }
  public int Code { get; private set; }
  public DateTime BirthDay { get; private set; }
  public string Sector { get; private set; }

  public Employee(string name, IdentifierDocument identifierDocument, DateTime birthDay, int code, string sector)
  {
    DomainException.ThrowsWhen(
      (string.IsNullOrWhiteSpace(name), "Name must not be empty"),
      (identifierDocument == null, "Identifier Document must not be empty"),
      (code <= 0, "Code must be greater than zero"),
      (string.IsNullOrWhiteSpace(sector), "Sector must not be empty")
    );

    Name = name;
    IdentifierDocument = identifierDocument!;
    BirthDay = birthDay;
    Code = code;
    Sector = sector;
  }
}

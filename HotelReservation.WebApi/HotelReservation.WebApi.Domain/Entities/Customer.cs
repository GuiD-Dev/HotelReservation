using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Domain.Entities;

public sealed class Customer : BaseEntity
{
  public string Name { get; private set; }
  public IdentifierDocument IdentifierDocument { get; private set; }
  public string Email { get; private set; }
  public string Phone { get; private set; }

  public Customer(string name, IdentifierDocument identifierDocument, string email, string phone)
  {
    DomainException.ThrowsWhen(
      (string.IsNullOrWhiteSpace(name), "Name must not be empty"),
      (identifierDocument == null, "Identifier Document must not be null"),
      (string.IsNullOrWhiteSpace(email), "Email must not be empty"),
      (string.IsNullOrWhiteSpace(phone), "Phone must not be empty")
    );

    Name = name;
    IdentifierDocument = identifierDocument!;
    Email = email;
    Phone = phone;
  }
}

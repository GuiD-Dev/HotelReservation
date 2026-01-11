using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Domain.Entities;

public class Customer : BaseEntity
{
  public string Name { get; private set; }
  public IdentifierDocument IdentifierDocument { get; private set; }
  public string Email { get; private set; }
  public string Phone { get; private set; }

  public Customer(string name, IdentifierDocument identifierDocument, string email, string phone)
  {
    DomainException.ThrowsWhen(
      (string.IsNullOrWhiteSpace(name), "Name cannot be empty."),
      (identifierDocument == null, "Identifier Document cannot be empty."),
      (string.IsNullOrWhiteSpace(email), "Email cannot be empty."),
      (string.IsNullOrWhiteSpace(phone), "Phone cannot be empty.")
    );

    Name = name;
    IdentifierDocument = identifierDocument!;
    Email = email;
    Phone = phone;
  }
}

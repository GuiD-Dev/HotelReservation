using System.Text.RegularExpressions;
using HotelReservation.WebApi.Domain.Exceptions;

namespace HotelReservation.WebApi.Domain.ValueObjects;

public sealed record IdentifierDocument
{
  public string Id { get; private set; }
  public DateTime ShippingDate { get; private set; }

  public IdentifierDocument(string id, DateTime shippingDate)
  {
    DomainException.ThrowsWhen(
      (string.IsNullOrWhiteSpace(id), "Id must not be empty"),
      (Regex.IsMatch(id, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$") is false, "Id's format specified does not match XXX.XXX.XXX-XX"),
      (shippingDate > DateTime.UtcNow, "Shipping date cannot be in the future")
    );

    Id = id;
    ShippingDate = shippingDate;
  }
}

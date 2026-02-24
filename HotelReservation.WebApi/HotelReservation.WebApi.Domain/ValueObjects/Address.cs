using System.ComponentModel.DataAnnotations.Schema;
using HotelReservation.WebApi.Domain.Exceptions;

namespace HotelReservation.WebApi.Domain.ValueObjects;

public sealed record Address
{
	public int Number { get; private set; }
	public string Street { get; private set; }
	public string City { get; private set; }
	public string State { get; private set; }
	public string Country { get; private set; }
	public string ZipCode { get; private set; }

	public Address(int number, string street, string city, string state, string country, string zipCode)
	{
		DomainException.ThrowsWhen(
			(number <= 0, "Number must be greater than zero"),
			(string.IsNullOrWhiteSpace(street), "Street must not be empty"),
			(string.IsNullOrWhiteSpace(city), "City must not be empty"),
			(string.IsNullOrWhiteSpace(state), "State must not be empty"),
			(string.IsNullOrWhiteSpace(country), "Country must not be empty"),
			(string.IsNullOrWhiteSpace(zipCode), "ZipCode must not be empty")
		);

		Number = number;
		Street = street;
		City = city;
		State = state;
		Country = country;
		ZipCode = zipCode;
	}
}

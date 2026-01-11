using System.ComponentModel.DataAnnotations.Schema;
using HotelReservation.WebApi.Domain.Exceptions;

namespace HotelReservation.WebApi.Domain.ValueObjects;

public class Address
{
	public int Number { get; private set; }
	public string Street { get; private set; }
	public string City { get; private set; }
	public string State { get; private set; }
	public string ZipCode { get; private set; }

	public Address(int number, string street, string city, string state, string zipCode)
	{
		DomainException.ThrowsWhen(
			(number <= 0, "Number is invalid"),
			(string.IsNullOrWhiteSpace(street), "Street is required"),
			(string.IsNullOrWhiteSpace(city), "City is required"),
			(string.IsNullOrWhiteSpace(state), "State is required"),
			(string.IsNullOrWhiteSpace(zipCode), "ZipCode is required")
		);

		Number = number;
		Street = street;
		City = city;
		State = state;
		ZipCode = zipCode;
	}
}

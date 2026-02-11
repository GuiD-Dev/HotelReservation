using FluentAssertions;
using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class EmployeeTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var name = "John Doe";
    var identifierDocument = new IdentifierDocument("999.999.999-99");
    var code = 12345;
    var birthDay = new DateTime(1990, 1, 1);
    var sector = "Front Desk";

    var employee = new Employee(name, identifierDocument, birthDay, code, sector);

    employee.Name.Should().Be(name);
    employee.IdentifierDocument.Should().Be(identifierDocument);
    employee.Code.Should().Be(code);
    employee.BirthDay.Should().Be(birthDay);
    employee.Sector.Should().Be(sector);
  }

  [Theory]
  [InlineData("", "999.999.999-99", 12345, "Front Desk", "Name must not be empty")]
  [InlineData("John Doe", null, 12345, "Front Desk", "Identifier Document must not be empty")]
  [InlineData("John Doe", "999.999.999-99", 0, "Front Desk", "Code must be greater than zero")]
  [InlineData("John Doe", "999.999.999-99", 12345, "", "Sector must not be empty")]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var name = (string)parameters[0];
    var id = (string?)parameters[1];
    var identifierDocument = id != null ? new IdentifierDocument(id) : null;
    var code = (int)parameters[2];
    var sector = (string)parameters[3];

    var exception = Assert.Throws<DomainException>(() => new Employee(name, identifierDocument, DateTime.Now, code, sector));

    var expectedMessage = (string)parameters[4];
    exception.Message.Should().Be(expectedMessage);
  }
}
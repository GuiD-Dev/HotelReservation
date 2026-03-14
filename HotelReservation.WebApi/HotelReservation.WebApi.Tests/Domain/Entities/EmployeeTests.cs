using FluentAssertions;
using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Tests.Domain.Entities;

public class EmployeeTests : IBaseTests
{
  [Fact]
  public void Should_Create_Entity()
  {
    var name = "John Doe";
    var identifierDocument = new IdentifierDocument("999.999.999-99", DateTime.UtcNow.AddDays(-1));
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

  public static IEnumerable<object[]> TestData => new List<object[]>
  {
    new object[] { "", new IdentifierDocument("999.999.999-99", DateTime.UtcNow.AddDays(-1)), 12345, "Front Desk", "Name must not be empty" },
    new object[] { "John Doe", null, 12345, "Front Desk", "Identifier Document must not be empty" },
    new object[] { "John Doe", new IdentifierDocument("999.999.999-99", DateTime.UtcNow.AddDays(-1)), 0, "Front Desk", "Code must be greater than zero" },
    new object[] { "John Doe", new IdentifierDocument("999.999.999-99", DateTime.UtcNow.AddDays(-1)), 12345, "", "Sector must not be empty" }
  };
  
  [Theory]
  [MemberData(nameof(TestData))]
  public void Should_Throw_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var name = (string)parameters[0];
    var identifierDocument = (IdentifierDocument)parameters[1];
    var code = (int)parameters[2];
    var sector = (string)parameters[3];

    var exception = Assert.Throws<DomainException>(() => new Employee(name, identifierDocument, DateTime.Now, code, sector));

    var expectedMessage = (string)parameters[4];
    exception.Message.Should().Be(expectedMessage);
  }
}
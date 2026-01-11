using HotelReservation.WebApi.Domain.Entities;
using HotelReservation.WebApi.Domain.Exceptions;
using HotelReservation.WebApi.Domain.ValueObjects;

namespace HotelReservation.WebApi.Test.Domain.Entities;

public class EmployeeTest : BaseTest
{
  [Fact]
  public override void Should_Create_Entity()
  {
    var name = "John Doe";
    var identifierDocument = new IdentifierDocument("999.999.999-99");
    var code = 12345;
    var birthDay = new DateTime(1990, 1, 1);
    var sector = "Front Desk";

    var employee = new Employee(name, identifierDocument, birthDay, code, sector);

    Assert.Equal(name, employee.Name);
    Assert.Equal(identifierDocument, employee.IdentifierDocument);
    Assert.Equal(code, employee.Code);
    Assert.Equal(birthDay, employee.BirthDay);
    Assert.Equal(sector, employee.Sector);
  }

  [Theory]
  [InlineData("", "999.999.999-99", 12345, "Front Desk")]
  [InlineData("John Doe", "", 12345, "Front Desk")]
  [InlineData("John Doe", "999.999.999-99", 0, "Front Desk")]
  [InlineData("John Doe", "999.999.999-99", 12345, "")]
  public override void Should_Throws_Exception_When_Invalid_Parameters(params dynamic[] parameters)
  {
    var name = (string)parameters[0];
    var identifierDocument = (string)parameters[1];
    var code = (int)parameters[2];
    var sector = (string)parameters[3];

    Assert.Throws<DomainException>(() => new Employee(name, new IdentifierDocument(identifierDocument), DateTime.Now, code, sector));
  }
}
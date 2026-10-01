using HotelReservation.Domain.Exceptions;
using HotelReservation.Domain.ValueObjects;

namespace HotelReservation.Domain.Entities;

public sealed class Hotel : BaseEntity
{
  public Address Address { get; private set; }
  public bool Active { get; private set; } = true;

  public ICollection<HotelRoom> Rooms { get; private set; } = [];
  public ICollection<Employee> Employees { get; private set; } = [];

  private Hotel() { }

  public Hotel(Address address)
  {
    DomainException.ThrowsWhen((address == null, "Address must be provided"));

    Address = address!;
  }

  public void Update(Address address)
  {
    DomainException.ThrowsWhen((address == null, "Address must be provided"));
    
    Address = address!;
  }

  public void AddRoom(HotelRoom room)
  {
    DomainException.ThrowsWhen((room == null, "Hotel room cannot be empty."));
    Rooms.Add(room!);
  }

  public void RemoveRoom(int roomId)
  {
    var room = Rooms.FirstOrDefault(r => r.Id == roomId);
    DomainException.ThrowsWhen((room == null, "Hotel room cannot be empty."));
    Rooms.Remove(room!);
  }

  public void AddEmployee(Employee employee)
  {
    DomainException.ThrowsWhen((employee == null, "Employee cannot be empty."));
    Employees.Add(employee!);
  }

  public void RemoveEmployee(int employeeId)
  {
    var employee = Employees.FirstOrDefault(e => e.Id == employeeId);
    Employees.Remove(employee!);
  }
}

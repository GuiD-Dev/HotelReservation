namespace WebApi.Domain.Events;

public interface IDomainEvent
{
  DateTime DateOccurred { get; }
}

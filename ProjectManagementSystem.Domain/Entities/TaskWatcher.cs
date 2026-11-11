namespace ProjectManagementSystem.Domain.Entities;

public class TaskWatcher
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
}
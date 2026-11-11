namespace ProjectManagementSystem.Domain.Entities;

public class SprintTask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SprintId { get; set; }
    public Guid TaskId { get; set; }
    public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.UtcNow;
}
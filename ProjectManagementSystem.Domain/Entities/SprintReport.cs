namespace ProjectManagementSystem.Domain.Entities;

public class SprintReport
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SprintId { get; set; }
    public decimal CommittedPoints { get; set; }
    public decimal CompletedPoints { get; set; }
    public decimal Velocity { get; set; }
    public DateTimeOffset GeneratedAt { get; set; } = DateTimeOffset.UtcNow;
}
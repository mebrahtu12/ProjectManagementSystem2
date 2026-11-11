namespace ProjectManagementSystem.Domain.Entities;

public class BaselineItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid BaselineId { get; set; }
    public Guid TaskId { get; set; }
    public DateOnly PlannedStart { get; set; }
    public DateOnly PlannedEnd { get; set; }
    public decimal PlannedEffort { get; set; }
}
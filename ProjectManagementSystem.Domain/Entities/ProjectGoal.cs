namespace ProjectManagementSystem.Domain.Entities;

public class ProjectGoal
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public Guid ParentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal TargetValue { get; set; }
    public decimal CurrentValue { get; set; }
    public DateOnly DueDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
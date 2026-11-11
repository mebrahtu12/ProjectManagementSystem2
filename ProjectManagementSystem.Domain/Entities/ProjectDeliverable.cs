namespace ProjectManagementSystem.Domain.Entities;

public class ProjectDeliverable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public Guid MilestoneId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateOnly DueDate { get; set; }
}
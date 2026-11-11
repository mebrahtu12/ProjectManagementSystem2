namespace ProjectManagementSystem.Domain.Entities;

public class Tasks
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public Guid PhaseId { get; set; }
    public Guid MilestoneId { get; set; }
    public Guid ParentTaskId { get; set; }
    public Guid StatusId { get; set; }
    public Guid PriorityId { get; set; }
    public Guid ReporterId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly DueDate { get; set; }
    public decimal Estimate { get; set; }
    public string SortKey { get; set; } = string.Empty;
}
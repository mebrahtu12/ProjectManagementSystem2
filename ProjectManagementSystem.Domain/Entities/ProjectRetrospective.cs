namespace ProjectManagementSystem.Domain.Entities;

public class ProjectRetrospective
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public Guid SprintId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateOnly HeldAt { get; set; }
}
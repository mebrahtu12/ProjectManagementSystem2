namespace ProjectManagementSystem.Domain.Entities;

public class WorkflowTransition
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public Guid FromStatusId { get; set; }
    public Guid ToStatusId { get; set; }
    public string Conditions { get; set; } = string.Empty;
}

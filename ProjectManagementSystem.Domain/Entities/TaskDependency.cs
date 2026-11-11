namespace ProjectManagementSystem.Domain.Entities;

public class TaskDependency
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PredecessorTaskId { get; set; }
    public Guid SuccessorTaskId { get; set; }
    public string Type { get; set; } = string.Empty;
    public int LagMinutes { get; set; }
}
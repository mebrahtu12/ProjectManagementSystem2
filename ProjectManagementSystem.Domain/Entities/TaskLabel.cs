namespace ProjectManagementSystem.Domain.Entities;

public class TaskLabel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TaskId { get; set; }
    public Guid LabelId { get; set; }
}

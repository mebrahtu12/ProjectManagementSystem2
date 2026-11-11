namespace ProjectManagementSystem.Domain.Entities;

public class GoalTaskLink
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid GoalId { get; set; }
    public Guid TaskId { get; set; }
    public decimal Weight { get; set; }
}
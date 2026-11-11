namespace ProjectManagementSystem.Domain.Entities;

public class Board
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BoardType { get; set; } = string.Empty;
}
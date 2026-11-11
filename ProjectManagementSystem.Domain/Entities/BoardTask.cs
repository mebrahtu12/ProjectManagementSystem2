namespace ProjectManagementSystem.Domain.Entities;

public class BoardTask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid BoardId { get; set; }
    public Guid ColumnId { get; set; }
    public Guid TaskId { get; set; }
    public string Rank { get; set; } = string.Empty;
}
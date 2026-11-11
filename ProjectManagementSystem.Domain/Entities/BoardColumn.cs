namespace ProjectManagementSystem.Domain.Entities;

public class BoardColumn
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid BoardId { get; set; }
    public Guid StatusId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public int WipLimit { get; set; }
}
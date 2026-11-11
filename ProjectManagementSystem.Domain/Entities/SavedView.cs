namespace ProjectManagementSystem.Domain.Entities;

public class SavedView
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ViewType { get; set; } = string.Empty;
    public string FilterJson { get; set; } = string.Empty;
    public bool IsShared { get; set; }
}
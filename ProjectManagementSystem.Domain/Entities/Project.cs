namespace ProjectManagementSystem.Domain.Entities;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrganizationId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly EndDate { get; set; }
    public Guid OwnerId { get; set; }
}
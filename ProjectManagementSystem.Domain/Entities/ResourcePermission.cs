namespace ProjectManagementSystem.Domain.Entities;

public class ResourcePermission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrganizationId { get; set; }
    public string ResourceType { get; set; } = string.Empty;
    public Guid ResourceId { get; set; }
    public string AccessLevel { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
}
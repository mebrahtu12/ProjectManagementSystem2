namespace ProjectManagementSystem.Domain.Entities;

public class MemberRole
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrganizationMemberId { get; set; }
    public Guid RoleId { get; set; }
    public DateTimeOffset AssignedAt { get; set; } = DateTimeOffset.UtcNow;
}

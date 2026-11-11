
namespace ProjectManagementSystem.Domain.Entities;

public class OrganizationMember
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrganizationId { get; set; }

    public Guid UserId { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTimeOffset JoinedAt { get; set; }
        = DateTimeOffset.UtcNow;

    public User User { get; set; } = null!;

    public Organization Organization { get; set; } = null!;
}

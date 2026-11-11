namespace ProjectManagementSystem.Domain.Entities;

public class SsoConnection
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrganizationId { get; set; }
    public string Protocol { get; set; } = string.Empty;
    public string Domain { get; set; } = string.Empty;
    public string Config { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

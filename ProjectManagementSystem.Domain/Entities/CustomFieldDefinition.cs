namespace ProjectManagementSystem.Domain.Entities;

public class CustomFieldDefinition
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string FieldType { get; set; } = string.Empty;
    public string Options { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
}
namespace ProjectManagementSystem.Domain.Entities;

public class CustomFieldValue
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TaskId { get; set; }
    public Guid FieldDefinitionId { get; set; }
    public string Value { get; set; } = string.Empty;
}
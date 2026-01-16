namespace Core.Entities.Prerequisites;

public class Prerequisite : BaseEntity
{
    public PrerequisiteOwnerType OwnerType { get; set; }
    public int OwnerId { get; set; }

    public int GroupId { get; set; }

    public PrerequisiteType Type { get; set; }
    public ComparisonOperator Operator { get; set; }
    public string Value { get; set; } = string.Empty;
}


namespace Core.Entities;

public class DictionaryItem : BaseEntity
{
    public string Name { get; set; }
    public int DictionaryId { get; set; }
    public Dictionary Dictionary { get; set; }

}

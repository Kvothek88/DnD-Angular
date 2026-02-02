namespace Core.Entities.Dictionaries;

public class DictionaryItem : BaseEntity
{
    public string Name { get; set; }
    public int DictionaryId { get; set; }
    public Dictionary Dictionary { get; set; }

}

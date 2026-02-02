namespace Core.Entities.Dictionaries;

public class DictionaryCategory : BaseEntity
{
    public string Name { get; set; }
    public List<Dictionary> Dictionaries { get; set; }
}

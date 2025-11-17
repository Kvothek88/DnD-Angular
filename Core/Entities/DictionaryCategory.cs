namespace Core.Entities;

public class DictionaryCategory : BaseEntity
{
    public string Name { get; set; }
    public List<Dictionary> Dictionaries { get; set; }
}

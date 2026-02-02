namespace Core.Entities.Dictionaries;

public class Dictionary : BaseEntity
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public DictionaryCategory Category { get; set; }

    public List<DictionaryItem> Items { get; set; }
}

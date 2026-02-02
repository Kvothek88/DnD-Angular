using Core.Entities.CharacterEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Advancement : BaseEntity
{
    public int CharacterId { get; set; }
    public Character Character { get; set; } = null!;
    public int Level { get; set; }
}

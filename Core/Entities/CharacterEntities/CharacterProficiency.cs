using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CharacterEntities;

public class CharacterProficiency : BaseEntity
{
    public int CharacterId { get; set; }

    public int GrantedProficiencyId { get; set; }
    public GrantedProficiency GrantedProficiency { get; set; } = null!;
}


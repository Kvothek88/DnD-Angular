using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public class SpellbookAddDto
{
    public List<SpellbookSpellAddDto>? SpellbookSpells { get; set; }
}

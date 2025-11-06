using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants;

public static class CharacterDefaults
{
    // Hit dice per class
    public static readonly Dictionary<string, int> ClassHitDice = new()
        {
            { "Artificer", 8},
            { "Barbarian", 12 },
            { "Bard", 8 },
            { "Cleric", 8 },
            { "Druid", 8 },
            { "Fighter", 10 },
            { "Monk", 8 },
            { "Paladin", 10 },
            { "Ranger", 10 },
            { "Rogue", 8 },
            { "Sorcerer", 6 },
            { "Warlock", 8 },
            { "Wizard", 6 }
        };

    // Base speed per race (in feet)
    public static readonly Dictionary<string, int> RaceSpeed = new()
        {
            { "Human", 30 },
            { "Elf", 35 },
            { "High Elf", 35 },
            { "Wood Elf", 35 },
            { "Dark Elf (Drow)", 30 },
            { "Dwarf", 25 },
            { "Hill Dwarf", 25 },
            { "Mountain Dwarf", 25 },
            { "Halfling", 25 },
            { "Lightfoot Halfling", 25 },
            { "Stout Halfling", 25 },
            { "Dragonborn", 30 },
            { "Gnome", 25 },
            { "Forest Gnome", 25 },
            { "Rock Gnome", 25 },
            { "Half-Orc", 30 },
            { "Half-Elf", 30 },
            { "Tiefling", 30 }
        };
}

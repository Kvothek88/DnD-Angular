using Core.Entities;

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

    public static readonly SpellSlotProgression FullCasterSlots = new SpellSlotProgression
    {
        Levels = new Dictionary<int, Dictionary<int, int>>
        {
            {1,  new(){ {1,2} }},
            {2,  new(){ {1,3} }},
            {3,  new(){ {1,4},{2,2} }},
            {4,  new(){ {1,4},{2,3} }},
            {5,  new(){ {1,4},{2,3},{3,2} }},
            {6,  new(){ {1,4},{2,3},{3,3} }},
            {7,  new(){ {1,4},{2,3},{3,3},{4,1} }},
            {8,  new(){ {1,4},{2,3},{3,3},{4,2} }},
            {9,  new(){ {1,4},{2,3},{3,3},{4,3},{5,1} }},
            {10, new(){ {1,4},{2,3},{3,3},{4,3},{5,2} }},
            {11, new(){ {1,4},{2,3},{3,3},{4,3},{5,2},{6,1} }},
            {12, new(){ {1,4},{2,3},{3,3},{4,3},{5,2},{6,1} }},
            {13, new(){ {1,4},{2,3},{3,3},{4,3},{5,2},{6,1},{7,1} }},
            {14, new(){ {1,4},{2,3},{3,3},{4,3},{5,2},{6,1},{7,1} }},
            {15, new(){ {1,4},{2,3},{3,3},{4,3},{5,2},{6,1},{7,1},{8,1} }},
            {16, new(){ {1,4},{2,3},{3,3},{4,3},{5,2},{6,1},{7,1},{8,1} }},
            {17, new(){ {1,4},{2,3},{3,3},{4,3},{5,2},{6,1},{7,1},{8,1},{9,1} }},
            {18, new(){ {1,4},{2,3},{3,3},{4,3},{5,3},{6,1},{7,1},{8,1},{9,1} }},
            {19, new(){ {1,4},{2,3},{3,3},{4,3},{5,3},{6,2},{7,1},{8,1},{9,1} }},
            {20, new(){ {1,4},{2,3},{3,3},{4,3},{5,3},{6,2},{7,2},{8,1},{9,1} }}
        }
    };

    public static readonly SpellSlotProgression HalfCasterSlots = new SpellSlotProgression
    {
        Levels = new Dictionary<int, Dictionary<int, int>>
        {
            {1,  new(){}},
            {2,  new(){ {1,2} }},
            {3,  new(){ {1,3} }},
            {4,  new(){ {1,3} }},
            {5,  new(){ {1,4},{2,2} }},
            {6,  new(){ {1,4},{2,2} }},
            {7,  new(){ {1,4},{2,3} }},
            {8,  new(){ {1,4},{2,3} }},
            {9,  new(){ {1,4},{2,3},{3,2} }},
            {10, new(){ {1,4},{2,3},{3,2} }},
            {11, new(){ {1,4},{2,3},{3,3} }},
            {12, new(){ {1,4},{2,3},{3,3} }},
            {13, new(){ {1,4},{2,3},{3,3},{4,1} }},
            {14, new(){ {1,4},{2,3},{3,3},{4,1} }},
            {15, new(){ {1,4},{2,3},{3,3},{4,2} }},
            {16, new(){ {1,4},{2,3},{3,3},{4,2} }},
            {17, new(){ {1,4},{2,3},{3,3},{4,3} }},
            {18, new(){ {1,4},{2,3},{3,3},{4,3} }},
            {19, new(){ {1,4},{2,3},{3,3},{4,3},{5,1} }},
            {20, new(){ {1,4},{2,3},{3,3},{4,3},{5,2} }},
        }
    };

    public static readonly Dictionary<string, SpellSlotProgression> Tables = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Bard"] = FullCasterSlots,
        ["Cleric"] = FullCasterSlots,
        ["Druid"] = FullCasterSlots,
        ["Sorcerer"] = FullCasterSlots,
        ["Wizard"] = FullCasterSlots,

        // 2024 change: Warlock uses Half-Caster slots now
        ["Paladin"] = HalfCasterSlots,
        ["Ranger"] = HalfCasterSlots,
        ["Warlock"] = HalfCasterSlots
    };

    public static CharacterSpellSlots CalculateSlots(string className, int level)
    {
        if (!Tables.TryGetValue(className, out var table))
            throw new Exception($"Unknown class '{className}' for spell slot calculation.");

        if (!table.Levels.TryGetValue(level, out var slotData))
            throw new Exception($"No spell slot data for level {level}.");

        CharacterSpellSlots slots = new CharacterSpellSlots
        {
            MaxLevel1 = slotData.GetValueOrDefault(1),
            MaxLevel2 = slotData.GetValueOrDefault(2),
            MaxLevel3 = slotData.GetValueOrDefault(3),
            MaxLevel4 = slotData.GetValueOrDefault(4),
            MaxLevel5 = slotData.GetValueOrDefault(5),
            MaxLevel6 = slotData.GetValueOrDefault(6),
            MaxLevel7 = slotData.GetValueOrDefault(7),
            MaxLevel8 = slotData.GetValueOrDefault(8),
            MaxLevel9 = slotData.GetValueOrDefault(9),

            UsedLevel1 = 0,
            UsedLevel2 = 0,
            UsedLevel3 = 0,
            UsedLevel4 = 0,
            UsedLevel5 = 0,
            UsedLevel6 = 0,
            UsedLevel7 = 0,
            UsedLevel8 = 0,
            UsedLevel9 = 0
        };

        return slots;
    }

}

public class SpellSlotProgression
{
    public Dictionary<int, Dictionary<int, int>> Levels { get; set; } = new();
}

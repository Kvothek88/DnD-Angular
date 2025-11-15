import { CharacterAbilities } from "./character-abilities";


export const abilityAbbr: { [key in Exclude<keyof CharacterAbilities, 'id'>]: string } = {
  strength: "STR",
  dexterity: "DEX",
  constitution: "CON",
  intelligence: "INT",
  wisdom: "WIS",
  charisma: "CHA",

  strengthModifier: "STR",
  dexterityModifier: "DEX",
  constitutionModifier: "CON",
  intelligenceModifier: "INT",
  wisdomModifier: "WIS",
  charismaModifier: "CHA",
};

export interface SkillConfig {
  name: string; // display name, can contain spaces e.g. "Animal Handling"
  key: string;  // internal key used for proficiency flag e.g. "animalHandling"
  ability: Exclude<keyof CharacterAbilities, 'id'>; // which modifier to use
}

export interface SavesConfig {
  name: string;
  ability: Exclude<keyof CharacterAbilities, 'id'>; 
}

export interface SkillInfo {
  name: string;        // display name
  key: string;         // internal key
  modifier: number;    // ability modifier
  proficiency: number; // proficiency bonus if proficient
  total: number;       // modifier + proficiency + itemBonus (if added)
  label: string;       // ability abbreviation e.g. "WIS"
}

export const skillsConfig: SkillConfig[] = [
  { name: 'Acrobatics', key: 'acrobatics', ability: 'dexterityModifier' },
  { name: 'Animal Handling', key: 'animalHandling', ability: 'wisdomModifier' },
  { name: 'Arcana', key: 'arcana', ability: 'intelligenceModifier' },
  { name: 'Athletics', key: 'athletics', ability: 'strengthModifier' },
  { name: 'Deception', key: 'deception', ability: 'charismaModifier' },
  { name: 'History', key: 'history', ability: 'intelligenceModifier' },
  { name: 'Insight', key: 'insight', ability: 'wisdomModifier' },
  { name: 'Intimidation', key: 'intimidation', ability: 'charismaModifier' },
  { name: 'Investigation', key: 'investigation', ability: 'intelligenceModifier' },
  { name: 'Medicine', key: 'medicine', ability: 'wisdomModifier' },
  { name: 'Nature', key: 'nature', ability: 'intelligenceModifier' },
  { name: 'Perception', key: 'perception', ability: 'wisdomModifier' },
  { name: 'Performance', key: 'performance', ability: 'charismaModifier' },
  { name: 'Persuasion', key: 'persuasion', ability: 'charismaModifier' },
  { name: 'Religion', key: 'religion', ability: 'intelligenceModifier' },
  { name: 'Sleight Of Hand', key: 'sleightOfHand', ability: 'dexterityModifier' },
  { name: 'Stealth', key: 'stealth', ability: 'dexterityModifier' },
  { name: 'Survival', key: 'survival', ability: 'wisdomModifier' },
];

export interface SavesInfo {
  name: string;
  modifier: number;
  proficiency: number;
  total: number;
}

export const savesConfig: SavesConfig[] = [
  { name: 'strength', ability: 'strengthModifier' },
  { name: 'dexterity', ability: 'dexterityModifier' },
  { name: 'constitution', ability: 'constitutionModifier' },
  { name: 'intelligence', ability: 'intelligenceModifier' },
  { name: 'wisdom', ability: 'wisdomModifier' },
  { name: 'charisma', ability: 'charismaModifier' },
]

export const portraits: string[] = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

export const races = ['Human', 'Elf', 'Drow Elf', 'Dwarf', 'Halfling', 'Dragonborn', 'Gnome', 'Half-Orc', 'Tiefling'];

export const classes = ['Barbarian', 'Bard', 'Cleric', 'Druid', 'Fighter', 'Monk', 'Paladin', 'Ranger', 'Rogue', 'Sorcerer', 'Warlock', 'Wizard', 'Artificer'];

export const subclasses: { [key: string]: string[] } = {
  Artificer: ['Alchemist', 'Armorer', 'Artillerist', 'Battle Smith'],
  Barbarian: ['Path of the Berserker', 'Path of the Totem Warrior', 'Path of the Ancestral Guardian', 'Path of the Storm Herald', 'Path of the Zealot'],
  Bard: ['College of Lore', 'College of Valor', 'College of Glamour', 'College of Swords', 'College of Whispers'],
  Cleric: ['Life Domain', 'War Domain', 'Light Domain', 'Knowledge Domain', 'Nature Domain', 'Tempest Domain', 'Trickery Domain', 'Death Domain', 'Forge Domain', 'Grave Domain'],
  Druid: ['Circle of the Land', 'Circle of the Moon', 'Circle of Dreams', 'Circle of the Shepherd', 'Circle of Spores'],
  Fighter: ['Champion', 'Battle Master', 'Eldritch Knight', 'Arcane Archer', 'Cavalier', 'Samurai'],
  Monk: ['Way of the Open Hand', 'Way of Shadow', 'Way of the Four Elements', 'Way of the Drunken Master', 'Way of the Kensei', 'Way of the Sun Soul'],
  Paladin: ['Oath of Devotion', 'Oath of the Ancients', 'Oath of Vengeance', 'Oath of Conquest', 'Oath of Redemption', 'Oathbreaker'],
  Ranger: ['Hunter', 'Beast Master', 'Gloom Stalker', 'Horizon Walker', 'Monster Slayer'],
  Rogue: ['Thief', 'Assassin', 'Arcane Trickster', 'Inquisitive', 'Mastermind', 'Scout', 'Swashbuckler'],
  Sorcerer: ['Draconic Bloodline', 'Wild Magic', 'Divine Soul', 'Shadow Magic', 'Storm Sorcery'],
  Warlock: ['The Fiend', 'The Archfey', 'The Great Old One', 'The Celestial', 'The Hexblade'],
  Wizard: ['Evocation', 'Necromancy', 'Illusion', 'Abjuration', 'Conjuration', 'Divination', 'Enchantment', 'Transmutation', 'War Magic']
};

export const sizes = ['Tiny', 'Small', 'Medium', 'Large', 'Huge', 'Gargantuan'];

export const alignments = [
  'Lawful Good', 'Neutral Good', 'Chaotic Good',
  'Lawful Neutral', 'True Neutral', 'Chaotic Neutral',
  'Lawful Evil', 'Neutral Evil', 'Chaotic Evil'
];

export const levels = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20];

export const savingThrowProficiencies: Record<string, string[]> = {
  Barbarian: ['Strength', 'Constitution'],
  Bard: ['Dexterity', 'Charisma'],
  Cleric: ['Wisdom', 'Charisma'],
  Druid: ['Intelligence', 'Wisdom'],
  Fighter: ['Strength', 'Constitution'],
  Monk: ['Strength', 'Dexterity'],
  Paladin: ['Wisdom', 'Charisma'],
  Ranger: ['Strength', 'Dexterity'],
  Rogue: ['Dexterity', 'Intelligence'],
  Sorcerer: ['Constitution', 'Charisma'],
  Warlock: ['Wisdom', 'Charisma'],
  Wizard: ['Intelligence', 'Wisdom'],
  Artificer: ['Constitution', 'Intelligence']
};

export const skillProficiencies: Record<string, string[]> = {
  Barbarian: ['Animal Handling', 'Athletics', 'Intimidation', 'Nature', 'Perception', 'Survival'],
  Bard: [
    'Acrobatics', 'Animal Handling', 'Arcana', 'Athletics', 'Deception', 'History',
    'Insight', 'Intimidation', 'Investigation', 'Medicine', 'Nature', 'Perception',
    'Performance', 'Persuasion', 'Religion', 'Sleight Of Hand', 'Stealth', 'Survival'
  ],
  Cleric: ['History', 'Insight', 'Medicine', 'Persuasion', 'Religion'],
  Druid: ['Animal Handling', 'Insight', 'Medicine', 'Nature', 'Perception', 'Religion', 'Survival'],
  Fighter: ['Acrobatics', 'Animal Handling', 'Athletics', 'History', 'Insight', 'Intimidation', 'Perception', 'Survival'],
  Monk: ['Acrobatics', 'Athletics', 'History', 'Insight', 'Religion', 'Stealth'],
  Paladin: ['Athletics', 'Insight', 'Intimidation', 'Medicine', 'Persuasion', 'Religion'],
  Ranger: ['Animal Handling', 'Athletics', 'Insight', 'Investigation', 'Nature', 'Perception', 'Stealth', 'Survival'],
  Rogue: ['Acrobatics', 'Athletics', 'Deception', 'Insight', 'Intimidation', 'Investigation', 'Perception', 'Performance', 'Persuasion', 'Sleight Of Hand', 'Stealth'],
  Sorcerer: ['Arcana', 'Deception', 'Insight', 'Intimidation', 'Persuasion', 'Religion'],
  Warlock: ['Arcana', 'Deception', 'History', 'Intimidation', 'Investigation', 'Nature', 'Religion'],
  Wizard: ['Arcana', 'History', 'Insight', 'Investigation', 'Medicine', 'Religion'],
  Artificer: ['Arcana', 'History', 'Investigation', 'Medicine', 'Nature', 'Perception', 'Sleight Of Hand'],
};

export const classesCantripsKnown: Record<string, number[]> = {
  Wizard:    [3,3,3,4,4,4,4,4,4,5,5,5,5,5,5,5,5,5,5,5],
  Cleric:    [3,3,3,4,4,4,4,4,4,5,5,5,5,5,5,5,5,5,5,5],
  Druid:     [2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4],
  Sorcerer:  [4,4,4,5,5,5,5,5,6,6,6,6,6,6,6,6,6,6,6,6],
  Paladin:   [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
  Ranger:    [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
  Warlock:   [2,2,2,3,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4]
};

export const classesMaxPreparedSpells: Record<string, number[]> = {
  Wizard:   [4,5,6,7,9,10,11,12,14,15,16,16,17,18,19,21,22,23,24,25],
  Cleric:   [4,5,6,7,9,10,11,12,14,15,16,16,17,17,18,18,19,20,21,22],
  Druid:    [4,5,6,7,9,10,11,12,14,15,16,16,17,17,18,18,19,20,21,22],
  Paladin:  [2,3,4,5,6,6,7,7,8,8,10,10,11,11,12,12,14,14,15,15],
  Ranger:   [2,3,4,5,6,6,7,7,8,8,10,10,11,11,12,12,14,14,15,15],
  Sorcerer: [2,4,6,7,9,10,11,12,14,15,16,16,17,17,18,18,19,20,21,22],
  Warlock:  [2,3,4,5,6,7,8,9,10,10,11,11,12,12,13,13,14,14,15,15]
};




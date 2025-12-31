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
  Warlock:   [2,2,2,3,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4],
  Bard:      [2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4],
  Paladin:   Array(20).fill(0),
  Ranger:    Array(20).fill(0),
  Barbarian: Array(20).fill(0),
  Fighter:   Array(20).fill(0),
  Monk:      Array(20).fill(0),
  Rogue:     Array(20).fill(0)
};

type ClassSpellInfo = { isSpellcaster: boolean; hasCantrips: boolean };

export const classSpellcasting: Record<string, ClassSpellInfo> = {
  Barbarian: { isSpellcaster: false, hasCantrips: false },
  Bard:      { isSpellcaster: true,  hasCantrips: true },
  Cleric:    { isSpellcaster: true,  hasCantrips: true },
  Druid:     { isSpellcaster: true,  hasCantrips: true },
  Fighter:   { isSpellcaster: false, hasCantrips: false },
  Monk:      { isSpellcaster: false, hasCantrips: false },
  Paladin:   { isSpellcaster: true,  hasCantrips: false },
  Ranger:    { isSpellcaster: true,  hasCantrips: false },
  Rogue:     { isSpellcaster: false, hasCantrips: false },
  Sorcerer:  { isSpellcaster: true,  hasCantrips: true },
  Warlock:   { isSpellcaster: true,  hasCantrips: true },
  Wizard:    { isSpellcaster: true,  hasCantrips: true }
};

export const classesMaxPreparedSpells: Record<string, number[]> = {
  Wizard:   [4,5,6,7,9,10,11,12,14,15,16,16,17,18,19,21,22,23,24,25],
  Cleric:   [4,5,6,7,9,10,11,12,14,15,16,16,17,17,18,18,19,20,21,22],
  Druid:    [4,5,6,7,9,10,11,12,14,15,16,16,17,17,18,18,19,20,21,22],
  Paladin:  [2,3,4,5,6,6,7,7,8,8,10,10,11,11,12,12,14,14,15,15],
  Ranger:   [2,3,4,5,6,6,7,7,8,8,10,10,11,11,12,12,14,14,15,15],
  Sorcerer: [2,4,6,7,9,10,11,12,14,15,16,16,17,17,18,18,19,20,21,22],
  Warlock:  [2,3,4,5,6,7,8,9,10,10,11,11,12,12,13,13,14,14,15,15],
  Bard:     [5,6,7,8,9,10,11,12,14,15,16,16,17,17,18,18,19,20,21,22]
};

export const proficiencyTypes = [
  { id: 2, name: 'Simple Weapons' },
  { id: 3, name: 'Martial Weapons' },
  { id: 4, name: 'Exotic Weapons' },
  { id: 5, name: 'Artisan Tools' },
  { id: 6, name: 'Gaming Sets' },
  { id: 7, name: 'Musical Instruments' },
  { id: 8, name: 'Other Tools' },
  { id: 9, name: 'Light Armor' },
  { id: 10, name: 'Medium Armor' },
  { id: 11, name: 'Heavy Armor' },
  { id: 12, name: 'Shields' },
];

export const proficiencyItems = [
    { id: 1, name: 'Club' },
    { id: 2, name: 'Dagger' },
    { id: 3, name: 'Greatclub' },
    { id: 4, name: 'Handaxe' },
    { id: 5, name: 'Javelin' },
    { id: 6, name: 'Light Hammer' },
    { id: 7, name: 'Mace' },
    { id: 8, name: 'Quarterstaff' },
    { id: 9, name: 'Sickle' },
    { id: 10, name: 'Spear' },
    { id: 11, name: 'Light Crossbow' },
    { id: 12, name: 'Dart' },
    { id: 13, name: 'Shortbow' },
    { id: 14, name: 'Sling' },
    { id: 15, name: 'Battleaxe' },
    { id: 16, name: 'Flail' },
    { id: 17, name: 'Glaive' },
    { id: 18, name: 'Greataxe' },
    { id: 19, name: 'Greatsword' },
    { id: 20, name: 'Halberd' },
    { id: 21, name: 'Lance' },
    { id: 22, name: 'Longsword' },
    { id: 23, name: 'Maul' },
    { id: 24, name: 'Morningstar' },
    { id: 25, name: 'Pike' },
    { id: 26, name: 'Rapier' },
    { id: 27, name: 'Scimitar' },
    { id: 28, name: 'Shortsword' },
    { id: 29, name: 'Trident' },
    { id: 30, name: 'WarPick' },
    { id: 31, name: 'Warhammer' },
    { id: 32, name: 'Whip' },
    { id: 33, name: 'Spiked Chain' },
    { id: 34, name: 'Katar' },
    { id: 35, name: 'Chakram' },
    { id: 36, name: 'Boomerang' },
    { id: 37, name: 'Blowgun' },
    { id: 38, name: 'Hand Crossbow' },
    { id: 39, name: 'Repeating Crossbow' },
    { id: 40, name: 'Buckler' },
    { id: 41, name: 'Alchemists Supplies' },
    { id: 42, name: 'Brewers Supplies' },
    { id: 43, name: 'Calligraphers Supplies' },
    { id: 44, name: 'Carpenters Tools' },
    { id: 45, name: 'Cartographers Tools' },
    { id: 46, name: 'Cobblers Tools' },
    { id: 47, name: 'Cooks Utensils' },
    { id: 48, name: 'Glassblowers Tools' },
    { id: 49, name: 'Jewelers Tools' },
    { id: 50, name: 'Leatherworkers Tools' },
    { id: 51, name: 'Masons Tools' },
    { id: 52, name: 'Painters Supplies' },
    { id: 53, name: 'Potters Tools' },
    { id: 54, name: 'Smiths Tools' },
    { id: 55, name: 'Tinkers Tools' },
    { id: 56, name: 'Weavers Tools' },
    { id: 57, name: 'Woodcarvers Tools' },
    { id: 58, name: 'Dice Set' },
    { id: 59, name: 'Playing Card Set' },
    { id: 60, name: 'Dragonchess Set' },
    { id: 61, name: 'Three Dragon Ante Set' },
    { id: 62, name: 'Bagpipes' },
    { id: 63, name: 'Drum' },
    { id: 64, name: 'Dulcimer' },
    { id: 65, name: 'Flute' },
    { id: 66, name: 'Lute' },
    { id: 67, name: 'Lyre' },
    { id: 68, name: 'Horn' },
    { id: 69, name: 'Pan Flute' },
    { id: 70, name: 'Shawm' },
    { id: 71, name: 'Viol' },
    { id: 72, name: 'Ocarina' },
    { id: 73, name: 'Tambourine' },
    { id: 74, name: 'Fiddle' },
    { id: 75, name: 'HandBell' },
    { id: 76, name: 'Disguise Kit' },
    { id: 77, name: 'Forgery Kit' },
    { id: 78, name: 'Herbalism Kit' },
    { id: 79, name: 'Navigators Tools' },
    { id: 80, name: 'Poisoners Kit' },
    { id: 81, name: 'Thieves Tools' },
    { id: 82, name: 'Vehicles Land' },
    { id: 83, name: 'Vehicles Water' },
    { id: 84, name: 'Padded' },
    { id: 85, name: 'Leather' },
    { id: 86, name: 'StuddedLeather' },
    { id: 87, name: 'Hide' },
    { id: 88, name: 'Chain Shirt' },
    { id: 89, name: 'Scale Mail' },
    { id: 90, name: 'Breastplate' },
    { id: 91, name: 'Half Plate' },
    { id: 92, name: 'Ring Mail' },
    { id: 93, name: 'Chain Mail' },
    { id: 94, name: 'Splint' },
    { id: 95, name: 'Plate' },
    { id: 96, name: 'Shield' },
  ];

export const classProficiencies: {
  [cls: string]: {
    Weapon: string[];
    Tools: string[];
    Armor: string[];
    Shield: string[];
  };
} = {
  Barbarian: {
    Weapon: ['Simple Weapons', 'Martial Weapons'],
    Tools: [],
    Armor: ['Light Armor', 'Medium Armor'],
    Shield: ['Shields']
  },

  Bard: {
    Weapon: ['Simple Weapons', 'Hand Crossbow', 'Longsword', 'Rapier', 'Shortsword'],
    Tools: ['Three Musical Instruments'],
    Armor: ['Light Armor'],
    Shield: []
  },

  Cleric: {
    Weapon: ['Simple Weapons'],
    Tools: [],
    Armor: ['Light Armor', 'Medium Armor'],
    Shield: ['Shields']
  },

  Druid: {
    Weapon: [
      'Clubs', 'Daggers', 'Darts', 'Javelins', 'Maces', 'Quarterstaffs',
      'Scimitars', 'Sickles', 'Slings', 'Spears'
    ],
    Tools: ['Herbalism Kit'],
    Armor: ['Light Armor', 'Medium Armor'],
    Shield: ['Shields'] // traditionally non-metal
  },

  Fighter: {
    Weapon: ['Simple Weapons', 'Martial Weapons'],
    Tools: [],
    Armor: ['Light Armor', 'Medium Armor', 'Heavy Armor'],
    Shield: ['Shields']
  },

  Monk: {
    Weapon: ['Simple Weapons', 'Shortsword'],
    Tools: ['One Artisan Tool or One Musical Instrument'],
    Armor: [],
    Shield: []
  },

  Paladin: {
    Weapon: ['Simple Weapons', 'Martial Weapons'],
    Tools: [],
    Armor: ['Light Armor', 'Medium Armor', 'Heavy Armor'],
    Shield: ['Shields']
  },

  Ranger: {
    Weapon: ['Simple Weapons', 'Martial Weapons'],
    Tools: [],
    Armor: ['Light Armor', 'Medium Armor'],
    Shield: ['Shields']
  },

  Rogue: {
    Weapon: ['Simple Weapons', 'Hand Crossbow', 'Longsword', 'Rapier', 'Shortsword'],
    Tools: ['Thieves’ Tools'],
    Armor: ['Light Armor'],
    Shield: []
  },

  Sorcerer: {
    Weapon: ['Daggers', 'Darts', 'Slings', 'Quarterstaffs', 'Light Crossbows'],
    Tools: [],
    Armor: [],
    Shield: []
  },

  Warlock: {
    Weapon: ['Simple Weapons'],
    Tools: [],
    Armor: ['Light Armor'],
    Shield: []
  },

  Wizard: {
    Weapon: ['Daggers', 'Darts', 'Slings', 'Quarterstaffs', 'Light Crossbows'],
    Tools: [],
    Armor: [],
    Shield: []
  }
};





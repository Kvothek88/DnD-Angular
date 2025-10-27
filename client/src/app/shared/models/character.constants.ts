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
  { name: 'Sleight of Hand', key: 'sleightOfHand', ability: 'dexterityModifier' },
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

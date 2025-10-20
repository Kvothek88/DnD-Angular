export interface CharacterAbilities {
  id: number;

  // Base stats
  strength: number;
  dexterity: number;
  constitution: number;
  intelligence: number;
  wisdom: number;
  charisma: number;

  // Calculated modifiers
  strengthModifier: number;
  dexterityModifier: number;
  constitutionModifier: number;
  intelligenceModifier: number;
  wisdomModifier: number;
  charismaModifier: number;
}
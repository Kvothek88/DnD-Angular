export interface CharacterSpellSlots {
  id: number;

  // Maximum spell slots per level
  maxLevel1: number;
  maxLevel2: number;
  maxLevel3: number;
  maxLevel4: number;
  maxLevel5: number;
  maxLevel6: number;
  maxLevel7: number;
  maxLevel8: number;
  maxLevel9: number;

  // Used spell slots per level
  usedLevel1: number;
  usedLevel2: number;
  usedLevel3: number;
  usedLevel4: number;
  usedLevel5: number;
  usedLevel6: number;
  usedLevel7: number;
  usedLevel8: number;
  usedLevel9: number;
}

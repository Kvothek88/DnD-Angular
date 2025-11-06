import { CreateCharacterAbilitiesDto } from "./create-character-abilities-dto";

export interface CreateCharacterDto {
  [key: string]: any; 
  name: string;
  race: string;
  background: string;
  religion: string;
  class: string;
  subclass: string;
  size: string;
  alignment: string;
  level: number;
  imageFrame: string;

  hitDice: number;
  maxHp: number;
  currentHp: number;

  speed: number;
  proficiencyBonus: number;
  initiative: number;

  // Saving Throws
  strengthSaveApplyProf: boolean;
  dexteritySaveApplyProf: boolean;
  constitutionSaveApplyProf: boolean;
  intelligenceSaveApplyProf: boolean;
  wisdomSaveApplyProf: boolean;
  charismaSaveApplyProf: boolean;

  // Skills
  acrobaticsApplyProf: boolean;
  animalHandlingApplyProf: boolean;
  arcanaApplyProf: boolean;
  athleticsApplyProf: boolean;
  deceptionApplyProf: boolean;
  historyApplyProf: boolean;
  insightApplyProf: boolean;
  intimidationApplyProf: boolean;
  investigationApplyProf: boolean;
  medicineApplyProf: boolean;
  natureApplyProf: boolean;
  perceptionApplyProf: boolean;
  performanceApplyProf: boolean;
  persuasionApplyProf: boolean;
  religionApplyProf: boolean;
  sleightOfHandApplyProf: boolean;
  stealthApplyProf: boolean;
  survivalApplyProf: boolean;

  // Abilities (required in backend)
  characterAbilities: CreateCharacterAbilitiesDto;
}
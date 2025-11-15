import { CharacterAbilities } from "./character-abilities";
import { CharacterSpellSlots } from "./character-spell-slots";
import { Spell } from "./spell";
import { Spellbook } from "./spellbook";

export interface Character {
    id: number;
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

    characterAbilities: CharacterAbilities;
    characterSpellSlots?: CharacterSpellSlots;
    characterPreparedSpells?: Spell[];

    hitDice: number;
    maxHp: number;
    currentHp: number;

    speed: number;
    proficiencyBonus: number;
    initiative: number;

    // Saving Throw Proficiencies
    strengthSaveApplyProf: boolean;
    dexteritySaveApplyProf: boolean;
    constitutionSaveApplyProf: boolean;
    intelligenceSaveApplyProf: boolean;
    wisdomSaveApplyProf: boolean;
    charismaSaveApplyProf: boolean;

    // Skills Proficiencies
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

    // Wizard specific
    spellbook?: Spellbook;
}
import { CharacterAbilities } from "./character-abilities";
import { CharacterSpellSlots } from "./character-spell-slots";
import { Spell } from "./spell";

export interface Character {
    id: number;
    name: string;
    race: string;
    background: string;
    religion: string;
    class: string;
    domain: string;
    size: string;
    alignment: string;
    level: number;

    characterAbilities: CharacterAbilities;
    characterSpellSlots: CharacterSpellSlots;
    characterSpells: Spell[];

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
}
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
    stats: any;
    characterSpellSlots: CharacterSpellSlots;
    spells: Spell[];
}
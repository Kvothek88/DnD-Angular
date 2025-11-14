import { Spell } from "./spell";

export interface Spellbook {
    id: number,
    characterId: number,
    spellbookSpells: Spell[]
}
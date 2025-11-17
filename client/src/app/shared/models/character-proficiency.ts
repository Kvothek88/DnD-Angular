import { ReferenceViewDto } from "./reference-view-dto";

export interface CharacterProficiency {
    characterId: number;
    proficiency: ReferenceViewDto;
    proficiencyType: ReferenceViewDto;
}
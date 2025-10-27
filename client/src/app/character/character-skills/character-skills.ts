import { Component, Input, SimpleChanges } from '@angular/core';
import { Character } from '../../shared/models/character';
import { abilityAbbr, SkillInfo, skillsConfig } from '../../shared/models/character.constants';
import { ModifierPipe } from "../../shared/pipes/modifier-pipe";

@Component({
  selector: 'app-character-skills',
  imports: [ModifierPipe],
  templateUrl: './character-skills.html',
  styleUrl: './character-skills.css'
})
export class CharacterSkills {
  
  @Input() character: Character | null = null;

  skills: SkillInfo[] = [];

  ngOnChanges(changes: SimpleChanges) {
    if (changes['character'] && this.character) {
      this.updateSkills();
    }
  }

  private updateSkills(): void {
    if (!this.character) return;

    this.skills = skillsConfig.map(skill => {
      const abilityModifier = this.character!.characterAbilities[skill.ability];

      // Character property like: acrobaticsApplyProf, animalHandlingApplyProf...
      const profKey = `${skill.key}ApplyProf` as keyof Character;
      const proficiency = this.character![profKey] ? this.character!.proficiencyBonus : 0;
      const total = abilityModifier + proficiency;

      return {
        name: skill.name,
        key: skill.key,
        modifier: abilityModifier,
        proficiency,
        total,
        label: abilityAbbr[skill.ability]
      };
    });
  }
}

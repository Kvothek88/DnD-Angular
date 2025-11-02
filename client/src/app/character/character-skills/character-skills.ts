import { Component, Input, SimpleChanges } from '@angular/core';
import { Character } from '../../shared/models/character';
import { abilityAbbr, SkillInfo, skillsConfig } from '../../shared/models/character.constants';
import { ModifierPipe } from "../../shared/pipes/modifier-pipe";
import { ToastService } from '../../shared/services/toast.service';

@Component({
  selector: 'app-character-skills',
  imports: [ModifierPipe],
  templateUrl: './character-skills.html',
  styleUrl: './character-skills.css'
})
export class CharacterSkills {

  constructor(private toastService: ToastService){}
  
  @Input() character: Character | null = null;

  skills: SkillInfo[] = [];

  ngOnChanges(changes: SimpleChanges) {
    if (changes['character'] && this.character) {
      this.updateSkills();
    }
  }

  skillCheck(modifier: number, name: string){
    const roll = Math.floor(Math.random() * 20) + 1;
    const proficiency = this.skills!.find(s => s.name == name)!.proficiency
    const result = roll + modifier + proficiency

    let totalBonus = String(modifier + proficiency);
    let totalBonus2 = String(modifier + proficiency);

    if (modifier + proficiency < 0){
      totalBonus = totalBonus.replaceAll("-", "");
      totalBonus2 = totalBonus2.replaceAll("-", "");
      totalBonus = '-' + totalBonus
      totalBonus2 = ' - ' + totalBonus2
    }
    else {
      totalBonus = '+' + totalBonus
      totalBonus2 = ' + ' + totalBonus2
    }
      
    this.toastService.show(`${name} Skill Check: 1d20${totalBonus} = ${roll}${totalBonus2} = ${result}`, 'dice')
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

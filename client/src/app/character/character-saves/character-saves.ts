import { Component, Input, SimpleChanges } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { savesConfig, SavesInfo } from '../../shared/models/character.constants';
import { ModifierPipe } from "../../shared/pipes/modifier-pipe";
import { ToastService } from '../../shared/services/toast.service';

@Component({
  selector: 'app-character-saves',
  imports: [FormsModule, CommonModule, ModifierPipe],
  templateUrl: './character-saves.html',
  styleUrl: './character-saves.css'
})
export class CharacterSaves {
  @Input() character: Character | null = null;

  constructor(private toastService: ToastService){}

  saves: SavesInfo[] = [];


  ngOnChanges(changes: SimpleChanges) {
    if (changes['character'] && this.character) {
      this.updateSavingThrows();
    }
  }

  savingThrow(ability: string, modifier: number){

    const numericModifier = Number(modifier);
    const roll = Math.floor(Math.random() * 20) + 1;
    const result = roll + numericModifier;
    ability = ability.charAt(0).toUpperCase() + ability.substring(1);

    this.toastService.show(`${ability} Saving Throw: 1d20+${numericModifier} = ${roll} + ${numericModifier} = ${result}`, 'success')
  }

  updateSavingThrows(): void {
    if (!this.character) return;

    this.saves = savesConfig.map(save => {
      const abilityModifier = this.character!.characterAbilities[save.ability];

      const profKey = `${save.name}SaveApplyProf` as keyof Character;
      const proficiency = this.character![profKey] ? this.character!.proficiencyBonus : 0;
      const total = abilityModifier + proficiency;

      return {
        name: save.name,
        modifier: abilityModifier,
        proficiency: proficiency,
        total: total
      }
    })
  }
}

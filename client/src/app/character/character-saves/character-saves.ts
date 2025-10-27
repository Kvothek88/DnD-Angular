import { Component, Input, SimpleChanges } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { savesConfig, SavesInfo } from '../../shared/models/character.constants';
import { ModifierPipe } from "../../shared/pipes/modifier-pipe";

@Component({
  selector: 'app-character-saves',
  imports: [FormsModule, CommonModule, ModifierPipe],
  templateUrl: './character-saves.html',
  styleUrl: './character-saves.css'
})
export class CharacterSaves {
  @Input() character: Character | null = null;

  saves: SavesInfo[] = [];


  ngOnChanges(changes: SimpleChanges) {
    if (changes['character'] && this.character) {
      this.updateSavingThrows();
    }
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

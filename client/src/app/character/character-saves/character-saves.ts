import { Component, Input, SimpleChanges } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-character-saves',
  imports: [FormsModule, CommonModule],
  templateUrl: './character-saves.html',
  styleUrl: './character-saves.css'
})
export class CharacterSaves {
  @Input() character: Character | null = null;

  strengthSaveBonus: number = 0;
  dexteritySaveBonus: number = 0;
  constitutionSaveBonus: number = 0;
  intelligenceSaveBonus: number = 0;
  wisdomSaveBonus: number = 0;
  charismaSaveBonus: number = 0;


  ngOnChanges(changes: SimpleChanges) {
    if (changes['character'] && this.character) {
      this.updateSavingThrows();
    }
  }

  calculateSave(ability: string): number {
    if (!this.character) return 0;

    switch (ability.toLowerCase()) {
      case 'strength':
        return this.character.characterAbilities.strengthModifier +
          (this.character.strengthSaveApplyProf ? this.character.proficiencyBonus : 0);

      case 'dexterity':
        return this.character.characterAbilities.dexterityModifier +
          (this.character.dexteritySaveApplyProf ? this.character.proficiencyBonus : 0);

      case 'constitution':
        return this.character.characterAbilities.constitutionModifier +
          (this.character.constitutionSaveApplyProf ? this.character.proficiencyBonus : 0);

      case 'intelligence':
        return this.character.characterAbilities.intelligenceModifier +
          (this.character.intelligenceSaveApplyProf ? this.character.proficiencyBonus : 0);

      case 'wisdom':
        return this.character.characterAbilities.wisdomModifier +
          (this.character.wisdomSaveApplyProf ? this.character.proficiencyBonus : 0);

      case 'charisma':
        return this.character.characterAbilities.charismaModifier +
          (this.character.charismaSaveApplyProf ? this.character.proficiencyBonus : 0);

      default:
        return 0;
    }
  }

  updateSavingThrows(): void {
    this.strengthSaveBonus = this.calculateSave('strength');
    this.dexteritySaveBonus = this.calculateSave('dexterity');
    this.constitutionSaveBonus = this.calculateSave('constitution');
    this.intelligenceSaveBonus = this.calculateSave('intelligence');
    this.wisdomSaveBonus = this.calculateSave('wisdom');
    this.charismaSaveBonus = this.calculateSave('charisma');
  }
}

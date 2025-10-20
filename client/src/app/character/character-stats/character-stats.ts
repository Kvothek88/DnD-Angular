import { Component, Input, SimpleChanges } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CharacterSpells } from "../character-spells/character-spells";
import { CharacterSaves } from "../character-saves/character-saves";
import { ModifierPipe } from "../../shared/pipes/modifier-pipe";
import { ToastService } from '../../shared/services/toast.service';

@Component({
  selector: 'app-character-stats',
  imports: [CommonModule, FormsModule, CharacterSpells, CharacterSaves, ModifierPipe],
  templateUrl: './character-stats.html',
  styleUrl: './character-stats.css'
})
export class CharacterStats {

  constructor(private toastService: ToastService){}

  @Input() character: Character | null = null;

  acTotal: number = 0;
  attackTotal: number = 0;
  spellAttackTotal: number = 0;
  spellSaveDC: number = 0;

  armor: number = 8;
  shield: number = 3;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['character'] && this.character) {
      this.acTotal = this.calculateACTotal();
      this.attackTotal = this.calculateAttackTotal();
      this.spellAttackTotal = this.calculateSpellAttackTotal();
      this.spellSaveDC = this.calculateSpellSaveDC();
    }
  }


  abilitySave(ability: string, modifier: string){

    const numericModifier = Number(modifier);
    const roll = Math.floor(Math.random() * 20) + 1;
    const result = roll + numericModifier;

    this.toastService.show(`${ability} Ability Save: 1d20 + ${numericModifier} = ${result}`, 'success')
  }

  calculateAttackTotal() : number {
    if (this.character)
      return this.character?.characterAbilities.strengthModifier + this.character?.proficiencyBonus
    else
      return 0;
  }

  calculateSpellAttackTotal(): number {
    if (this.character)
      return this.character?.characterAbilities.wisdomModifier + this.character?.proficiencyBonus
    else
      return 0;
  }

  calculateSpellSaveDC(): number {
    if (this.character)
      return this.character?.characterAbilities.wisdomModifier + this.character?.proficiencyBonus + 8
    else
      return 0;
  }

  calculateACTotal(): number {
    if (this.character)
      return (this.armor == 8 ? 0 : this.character?.characterAbilities.dexterityModifier) + this.armor + this.shield + 10
    else
      return 0; 
  }
}

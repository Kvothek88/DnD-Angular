import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CharacterSpells } from "../character-spells/character-spells";
import { CharacterSaves } from "../character-saves/character-saves";
import { ModifierPipe } from "../../shared/pipes/modifier-pipe";
import { ToastService } from '../../shared/services/toast.service';
import { CharacterSkills } from "../character-skills/character-skills";
import { CharacterStateService } from '../../shared/services/character-state.service';

@Component({
  selector: 'app-character-stats',
  standalone: true,
  imports: [CommonModule, FormsModule, CharacterSpells, CharacterSaves, ModifierPipe, CharacterSkills],
  templateUrl: './character-stats.html',
  styleUrl: './character-stats.css'
})
export class CharacterStats implements OnInit {

  constructor(
    private toastService: ToastService,
    private characterStateService: CharacterStateService){}

  ngOnInit(): void {
    this.characterStateService.innateSorceryActive$
      .subscribe(val => {
        this.innateSorceryActive = val;
        this.spellSaveDC = this.calculateSpellSaveDC();
      });
  }

  @Input() character: Character | null = null;

  acTotal: number = 0;
  attackTotal: number = 0;
  spellAttackTotal: number = 0;
  spellSaveDC: number = 0;

  armor: number = 8;
  shield: number = 3;

  // Sorcerer specific
  innateSorceryActive = false;

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

    this.toastService.show(`${ability} Ability Save: 1d20+${numericModifier} = ${roll} + ${numericModifier} = ${result}`, 'success')
  }

  attackDice(strModifier: number){
    const roll = Math.floor(Math.random() * 20) + 1;
    const result = roll + strModifier + this.character!.proficiencyBonus;

    this.toastService.show(`Attack: 1d20+${strModifier + this.character!.proficiencyBonus} = ${roll} + ${strModifier + this.character!.proficiencyBonus} = ${result}` , 'success')

    if (result == 20)
      this.toastService.show('Critical Hit!', 'success')
  }

  spellAttackDice(wisModifier: number){
    const roll = Math.floor(Math.random() * 20) + 1;
    const result = roll + wisModifier + this.character!.proficiencyBonus;

    this.toastService.show(`Spell Attack: 1d20+${wisModifier + this.character!.proficiencyBonus} = ${roll} + ${wisModifier + this.character!.proficiencyBonus} = ${result}` , 'success')

    if (result == 20)
      this.toastService.show('Critical Hit!', 'success')
  }

  initiativeDice(dexModifier: number){
    const roll1 = Math.floor(Math.random() * 20) + 1;
    const roll2 = Math.floor(Math.random() * 20) + 1;
    const roll = Math.max(roll1, roll2)
    const result = roll + dexModifier; 

    this.toastService.show(`Initiative: 1d20 + ${dexModifier} = ${result}`, 'twilight')
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
      return this.character?.characterAbilities.wisdomModifier + this.character?.proficiencyBonus + 8 + (this.innateSorceryActive === true ? 1 : 0);
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

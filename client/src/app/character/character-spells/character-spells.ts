import { Component, Input, SimpleChanges } from '@angular/core';
import { Character } from '../../shared/models/character';
import { groupBy } from 'lodash';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-character-spells',
  imports: [CommonModule , FormsModule],
  templateUrl: './character-spells.html',
  styleUrl: './character-spells.css'
})
export class CharacterSpells {
  @Input() character: Character | null = null;

  spellsByLevel: { [key: number]: any[] } = {};
  maxSlots: number[][] = [];
  usedSlots: { [key: number]: number } = {};

  ngOnChanges(changes: SimpleChanges) {
    if (changes['character'] && this.character?.characterPreparedSpells) {
      this.spellsByLevel = groupBy(this.character.characterPreparedSpells, 'level');
      this.maxSlots = this.getMaxSlots();
      this.usedSlots = this.getUsedSlots();
      console.log(this.maxSlots)
      console.log(this.usedSlots)
    }
  }

  getMaxSlots(): number[][] {
    let result: number[][] = Array.from({ length: 10 }, () => []);

    if (!this.character?.characterSpellSlots) {
      return result;
    }

    for (let level = 1; level <= 9; level++) {
      const max = (this.character.characterSpellSlots as any)[`maxLevel${level}`];
      

      for (let i = 0; i < max; i++){
        result[level].push(i);
      }
    }
    
    return result;
  }

  getUsedSlots(): { [key: number]: number } {
    let result: { [key: number]: number } = {};

    if (!this.character?.characterSpellSlots) {
      return result;
    }

    for (let level = 1; level <= 9; level++) {
      const used = (this.character.characterSpellSlots as any)[`usedLevel${level}`];
      result[level] = used;
    }

    return result;
  }

  // Helper to get sorted spell levels
  getSpellLevels(): number[] {
    return Object.keys(this.spellsByLevel)
      .map(Number)
      .sort((a, b) => a - b);
  }
}

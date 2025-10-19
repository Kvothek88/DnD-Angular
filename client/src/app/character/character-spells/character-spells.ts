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

  ngOnChanges(changes: SimpleChanges) {
    if (changes['character'] && this.character?.spells) {
      this.spellsByLevel = groupBy(this.character.spells, 'level');
    }
  }

  // Helper to get sorted spell levels
  getSpellLevels(): number[] {
    return Object.keys(this.spellsByLevel)
      .map(Number)
      .sort((a, b) => a - b);
  }
}

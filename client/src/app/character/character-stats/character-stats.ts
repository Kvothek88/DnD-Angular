import { Component, Input } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CharacterSpells } from "../character-spells/character-spells";

@Component({
  selector: 'app-character-stats',
  imports: [CommonModule, FormsModule, CharacterSpells],
  templateUrl: './character-stats.html',
  styleUrl: './character-stats.css'
})
export class CharacterStats {
  @Input() character: Character | null = null;
}

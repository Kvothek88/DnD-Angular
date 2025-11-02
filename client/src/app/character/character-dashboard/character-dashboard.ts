import { Component, Input } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DiceRoller } from "../../features/dice-roller/dice-roller";

@Component({
  selector: 'app-character-dashboard',
  imports: [CommonModule, FormsModule, RouterModule, DiceRoller],
  templateUrl: './character-dashboard.html',
  styleUrl: './character-dashboard.css'
})
export class CharacterDashboard {
  @Input() character: Character | null = null;
}

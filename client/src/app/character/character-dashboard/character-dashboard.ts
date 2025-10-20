import { Component, Input } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-character-dashboard',
  imports: [CommonModule, FormsModule],
  templateUrl: './character-dashboard.html',
  styleUrl: './character-dashboard.css'
})
export class CharacterDashboard {
  @Input() character: Character | null = null;
}

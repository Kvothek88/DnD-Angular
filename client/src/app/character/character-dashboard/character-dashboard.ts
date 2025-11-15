import { Component, Input } from '@angular/core';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DiceRoller } from "../../features/dice-roller/dice-roller";
import { ToastService } from '../../shared/services/toast.service';
import { CharacterStateService } from '../../shared/services/character-state.service';

@Component({
  selector: 'app-character-dashboard',
  imports: [CommonModule, FormsModule, RouterModule, DiceRoller],
  templateUrl: './character-dashboard.html',
  styleUrl: './character-dashboard.css'
})
export class CharacterDashboard {
  @Input() character: Character | null = null;

  constructor(
    private toastService: ToastService,
    private characterStateService: CharacterStateService) {}

  wildShapeForm : number = 0;

  wildShape() {
    if (this.wildShapeForm === 0) {
      const choice = parseInt(prompt("Choose your Wild Shape:\n1 - Dire Wolf\n2 - Dire Bear\n3 - Hawk") || "0", 10);
      if ([1, 2, 3].includes(choice)) {
        this.wildShapeForm = choice;
      } else {
        this.toastService.show("Invalid choice", 'error')
      }
    } else {
      this.wildShapeForm = 0;
    }
  }

  toggleInnateSorcery() {
    this.characterStateService.toggleInnateSorcery();
  }

}


import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CharacterService } from '../../shared/services/character.service';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { finalize } from 'rxjs';
import { CharacterStats } from "../character-stats/character-stats";
import { CharacterDashboard } from "../character-dashboard/character-dashboard";

@Component({
  selector: 'app-character-main',
  imports: [CommonModule, FormsModule, CharacterStats, CharacterDashboard],
  standalone: true,
  templateUrl: './character-main.html',
  styleUrl: './character-main.css'
})
export class CharacterMain implements OnInit {

  private characterService = inject(CharacterService);
  private cdr = inject(ChangeDetectorRef);
  
  isLoading = true;
  error: string | null = null;
  character: Character | null = null;

  

  ngOnInit(): void {
    this.characterService.getCharacter(1)
      .pipe(finalize(() => {
        this.isLoading = false;
        this.cdr.detectChanges();
      }))
      .subscribe({
        next: character => {
          this.character = character;
        },
        error: err => {
          console.error(err);
          this.error = 'Failed to load character data';
        }
      });
  }
}

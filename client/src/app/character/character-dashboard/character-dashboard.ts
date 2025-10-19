import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CharacterService } from '../../shared/services/character.service';
import { Character } from '../../shared/models/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { finalize } from 'rxjs';
import { CharacterStats } from "../character-stats/character-stats";

@Component({
  selector: 'app-character-dashboard',
  imports: [CommonModule, FormsModule, CharacterStats],
  standalone: true,
  templateUrl: './character-dashboard.html',
  styleUrl: './character-dashboard.css'
})
export class CharacterDashboard implements OnInit {

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
